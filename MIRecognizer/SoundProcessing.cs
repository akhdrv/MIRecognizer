using System;
using Un4seen.Bass;

namespace MIRecognizer
{
    class SoundProcessing : IDisposable
    {
        int sPointer = 0;

        public bool Playing => (sPointer != 0) ? Bass.BASS_ChannelIsActive(sPointer) == BASSActive.BASS_ACTIVE_PLAYING : false;
        public double CurrentPosition
        {
            get => (sPointer != 0) ? Bass.BASS_ChannelGetPosition(sPointer) / (Bass.BASS_ChannelGetLength(sPointer) - 1d) : double.NaN;
            set
            {
                if (sPointer != 0)
                    Bass.BASS_ChannelSetPosition(sPointer, Math.Max(Convert.ToInt64(Bass.BASS_ChannelGetLength(sPointer) * ((value < 0) ? 0 : (value > 1) ? 1 : value)) - 1, 0));
            }
        }
        public TimeSpan CurrentTime => (sPointer != 0) ? new TimeSpan((long)(Bass.BASS_ChannelBytes2Seconds(sPointer, Bass.BASS_ChannelGetPosition(sPointer)) * Math.Pow(10, 7))) : TimeSpan.Zero;
        public TimeSpan TrackLength => (sPointer != 0) ? new TimeSpan((long)(Bass.BASS_ChannelBytes2Seconds(sPointer, Bass.BASS_ChannelGetLength(sPointer)) * Math.Pow(10, 7))) : TimeSpan.Zero;

        public SoundProcessing(IntPtr windowHandle)
        {
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, windowHandle))
                throw new Exception($"Ошибка библиотеки BASS. {Bass.BASS_ErrorGetCode().ToString()}");
        }
        public SoundProcessing() : this(IntPtr.Zero) { }

        public void OpenFile(string filePath)
        {
            if (sPointer != 0)
                Bass.BASS_StreamFree(sPointer);
            int stream = Bass.BASS_StreamCreateFile(filePath, 0, 0, BASSFlag.BASS_DEFAULT);
            if (stream == 0)
                throw new Exception($"Ошибка при открытии файла. {Bass.BASS_ErrorGetCode().ToString()}");
            sPointer = stream;
        }

        public void Play()
        {
            if (sPointer == 0)
                throw new NotSupportedException("Не назначен файл для проигрывания.");
            Bass.BASS_ChannelPlay(sPointer, false);
        }

        public void Pause()
        {
            if (sPointer == 0)
                throw new NotSupportedException("Не назначен файл для проигрывания.");
            Bass.BASS_ChannelPause(sPointer);
        }

        public void Stop()
        {
            if (sPointer == 0)
                throw new NotSupportedException("Не назначен файл для проигрывания.");
            Bass.BASS_ChannelStop(sPointer);
            Bass.BASS_ChannelSetPosition(sPointer, 0);
        }

        public void Dispose()
        {
            Bass.BASS_Free();
        }
    }
}
