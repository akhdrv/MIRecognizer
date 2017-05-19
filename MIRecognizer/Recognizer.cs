using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using Wolfram.NETLink;

namespace MIRecognizer
{
    /// <summary>
    /// Класс, обеспечивающий работу с ядром системы Wolfram Mathematica, составляющий запрос на распознавание и обеспечивающий форматирование выходных данных.
    /// Кэширует (сохраняет) данные о распознанных аудиофайлах.
    /// </summary>
    class Recognizer : IDisposable
    {
        /// <summary>
        /// Ссылка на подключение к системе Mathematica
        /// </summary>
        IKernelLink mathematicaLink;

        public Recognizer()
        {
            mathematicaLink = MathLinkFactory.
                CreateKernelLink();
            mathematicaLink.WaitAndDiscardAnswer();

            var netPath = Path.Combine(
                Path.GetTempPath(), "InstrumentRecognizer",
                "net.wlnet");
            if (!File.Exists(netPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(netPath));
                File.Copy("net.wlnet", netPath, true);
            }
            mathematicaLink.Evaluate($"net = Import[\"{netPath.Replace('\\', '/')}\"];");
            mathematicaLink.WaitAndDiscardAnswer();
        }

        /// <summary>
        /// Возвращает форматированные данные о распознанных инструментах композиции
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Двумерный массив данных распознавания double[x, y], где x — номер секунды, в которой проходило распознавание, y — номер инструмента</returns>
        public double[,] GetInstrumentalInfo(string filePath)
        {
            if (Cached(filePath))
                return ReleaseFromCache(filePath);
            return Recognize(filePath);
        }

        /// <summary>
        /// Отправляет запрос о распознавании в систему Mathematica и возвращает форматированные данные
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Двумерный массив данных распознавания double[x, y], где x — номер секунды, в которой проходило распознавание, y — номер инструмента</returns>
        private double[,] Recognize(string filePath)
        {
            mathematicaLink.Evaluate(
                $@"audio = AudioNormalize[Import[""{filePath.Replace('\\', '/')}""]];
net[ImageTrim[Spectrogram[#, Frame -> None, ImageSize -> 254, AspectRatio -> 2,
ColorFunction -> GrayLevel, SampleRate -> 44800], {{ {{0, 0}}, {{254, 254}} }}]] & /@
AudioSplit[audio, Table[i, {{i, QuantityMagnitude[Duration[audio], ""Seconds""]}}]]");
            mathematicaLink.WaitForAnswer();


            var probabilities = (double[,])mathematicaLink
                .GetArray(typeof(double), 2);

            Cache(filePath, probabilities);

            return probabilities;
        }

        /// <summary>
        /// Сигнализирует, есть ли кэшированные данные для файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        private static bool Cached(string filePath)
        {
            if (File.Exists(CachedDataPath(filePath)))
                    return true;
            return false;
        }

        /// <summary>
        /// Кэширует данные распознавания
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="probabilities">Массив с распознанными данными</param>
        private static void Cache(string filePath, double[,] probabilities)
        {
            if (!Directory.Exists(Path.GetDirectoryName(CachedDataPath(filePath))))
                Directory.CreateDirectory(Path.GetDirectoryName(CachedDataPath(filePath)));
            using (var stream = new FileStream(
                CachedDataPath(filePath), FileMode.Create))
                    new BinaryFormatter().Serialize(stream, 
                        probabilities);
        }

        /// <summary>
        /// Возвращает путь к файлу с кэшированными данными
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        private static string CachedDataPath(string filePath)
        {
            using (var md5 = MD5.Create())
                return Path.Combine(Path.GetTempPath(),
                    "InstrumentRecognizer", "CachedData", (filePath != String.Empty) ?
                        BitConverter.ToString(md5.ComputeHash(
                            File.ReadAllBytes(filePath))).Replace(
                            "-", String.Empty) + ".dat" : String.Empty);
        }

        /// <summary>
        /// Удаляет папку с кэшированными данными
        /// </summary>
        public static void ClearCache()
        {
            Directory.Delete(CachedDataPath(String.Empty), true);
        }

        /// <summary>
        /// Извлекает данные из кэша для данного файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Данные распознавания</returns>
        private static double[,] ReleaseFromCache(string filePath)
        {
            using (var stream = new FileStream(CachedDataPath(filePath), FileMode.Open))
                return (double[,])(new BinaryFormatter().Deserialize(stream));
        }

        public void Dispose()
        {
            mathematicaLink?.Close();
            mathematicaLink = null;
        }
    }
}