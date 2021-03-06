﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using Wolfram.NETLink;

namespace MIRecognizer
{
    /// <summary>
    /// Класс, обеспечивающий работу с ядром системы Wolfram Mathematica, составляющий запрос на распознавание и обеспечивающий форматирование выходных данных.
    /// Кэширует данные о распознанных аудиофайлах.
    /// </summary>
    class Recognizer : IDisposable
    {
        private IKernelLink mathematicaLink;

        public void Initialize()
        {
            mathematicaLink = MathLinkFactory.
                CreateKernelLink();
            mathematicaLink.WaitAndDiscardAnswer();

            var netPath = Path.Combine(
                TemporaryPath, "InstrumentRecognizer",
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
            mathematicaLink.Evaluate($@"
audio = AudioNormalize[Import[""{filePath.Replace('\\', '/')}""]];
net[Sharpen[Spectrogram[#, Frame -> None, ImageSize -> {{768, 512}}, AspectRatio -> Full, 
  ColorFunction -> GrayLevel, SampleRate -> 44800]]] & /@
AudioSplit[audio, Table[i, {{i, 0, QuantityMagnitude[Duration[audio], ""Seconds""], 3}}]]");
            mathematicaLink.WaitForAnswer();

            var probabilities = (double[,])mathematicaLink
                .GetArray(typeof(double), 2);

            Cache(filePath, probabilities);

            mathematicaLink.Evaluate(@"Clear[%,audio];");
            mathematicaLink.WaitAndDiscardAnswer();

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
                return Path.Combine(TemporaryPath,
                    "InstrumentRecognizer", "CachedData", (filePath != String.Empty) ?
                        BitConverter.ToString(md5.ComputeHash(
                            File.ReadAllBytes(filePath))).Replace(
                            "-", String.Empty) + ".dat" : String.Empty);
        }

        private static string TemporaryPath { get; } = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\Temp");

        /// <summary>
        /// Удаляет папку с кэшированными данными
        /// </summary>
        public static void ClearCache()
        {
            if (Directory.Exists(CachedDataPath(String.Empty)))
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
        }
    }
}