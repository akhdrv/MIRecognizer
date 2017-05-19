using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using Wolfram.NETLink;

namespace MIRecognizer
{
    class Recognizer : IDisposable
    {
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
        public double[,] GetInstrumentalInfo(string filePath)
        {
            if (Cached(filePath))
                return ReleaseFromCache(filePath);
            return Recognize(filePath);
        }
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

        private static bool Cached(string filePath)
        {
            if (File.Exists(CachedDataPath(filePath)))
                    return true;
            return false;
        }

        private static void Cache(string filePath, double[,] probabilities)
        {
            if (!Directory.Exists(Path.GetDirectoryName(CachedDataPath(filePath))))
                Directory.CreateDirectory(Path.GetDirectoryName(CachedDataPath(filePath)));
            using (var stream = new FileStream(
                CachedDataPath(filePath), FileMode.Create))
                    new BinaryFormatter().Serialize(stream, 
                        probabilities);
        }

        private static string CachedDataPath(string filePath)
        {
            using (var md5 = MD5.Create())
                return Path.Combine(Path.GetTempPath(),
                    "InstrumentRecognizer", "CachedData", (filePath != String.Empty) ?
                        BitConverter.ToString(md5.ComputeHash(
                            File.ReadAllBytes(filePath))).Replace(
                            "-", String.Empty) + ".dat" : String.Empty);
        }

        public static void ClearCache()
        {
            Directory.Delete(CachedDataPath(String.Empty), true);
        }
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