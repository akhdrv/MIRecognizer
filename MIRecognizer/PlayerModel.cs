using System;
using System.IO;

namespace MIRecognizer
{
    public class InstrumentalProbabilities
    {
        private double[] probabilities;
        public double Cello => probabilities[0];
        public double Violin => probabilities[7];
        public double Flute => probabilities[1];
        public double Sax => probabilities[6];
        public double AcGuitar => probabilities[2];
        public double ElGuitar => probabilities[3];
        public double Organ => probabilities[4];
        public double Piano => probabilities[5];
        public double Voice => probabilities[8];
        public double Drums => probabilities[9];
        public InstrumentalProbabilities(double[] probabilities)
        {
            if (probabilities.Length == 10)
                this.probabilities = probabilities;
        }
    }
    class PlayerModel : IDisposable
    {
        private Recognizer recognizer;
        private SoundProcessing sound;
        private double[,] instrumentalInfo;

        public string TrackName { get; private set; }
        public bool Ready { get; private set; }
        public TimeSpan TrackLength => sound.TrackLength;
        public bool Playing => sound.Playing;
        public double PlaybackPosition
        {
            get => sound.CurrentPosition;
            set => sound.CurrentPosition = value;
        }

        public PlayerModel(IntPtr handle)
        {
            recognizer = new Recognizer();
            sound = new SoundProcessing(handle);
        }

        public void ClearCache() => Recognizer.ClearCache();
        public void Play() => sound.Play();
        public void Stop() => sound.Stop();
        public void Pause() => sound.Pause();

        public void Initialize() => recognizer.Initialize();

        public void OpenFile(string path)
        {
            if (Ready)
                Stop();

            Ready = false;

            instrumentalInfo = recognizer.GetInstrumentalInfo(path);
            sound.OpenFile(path);

            TrackName = Path.GetFileName(path);
            Ready = true;
        }

        public InstrumentalProbabilities GetCurrentProbabilities()
        {
            var blockNumber = Math.Min(Convert.ToInt32(PlaybackPosition *
                TrackLength.TotalSeconds / 3), instrumentalInfo.GetLength(0) - 1);
            var probabilities = new double[instrumentalInfo.GetLength(1)];

            for (int i = 0; i < probabilities.Length; ++i)
                probabilities[i] = instrumentalInfo[blockNumber, i];

            return new InstrumentalProbabilities(probabilities);
        }

        public void Dispose()
        {
            sound?.Dispose();
            recognizer?.Dispose();
        }
    }
}
