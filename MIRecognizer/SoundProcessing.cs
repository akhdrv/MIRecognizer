using System;
using Un4seen.Bass;

namespace MIRecognizer
{
    /// <summary>
    /// Класс, позволяющий воспроизводить музыкальные файлы большинства форматов и реализующий удобные манипуляции с воспроизведением.
    /// </summary>
    class SoundProcessing : IDisposable
    {
        /// <summary>
        /// Число, идентифицирующее текущий звуковой поток
        /// </summary>
        int sPointer = 0;

        /// <summary>
        /// Сигнализирует, играет ли музыка
        /// </summary>
        public bool Playing => (sPointer != 0) ? Bass.BASS_ChannelIsActive(sPointer) == BASSActive.BASS_ACTIVE_PLAYING : false;

        /// <summary>
        /// Устанавливает или возвращает число из промежутка [0,1], обозначающее текущую позицию воспроизведения
        /// </summary>
        public double CurrentPosition
        {
            get => (sPointer != 0) ? Bass.BASS_ChannelGetPosition(sPointer) / (Bass.BASS_ChannelGetLength(sPointer) - 1d) : double.NaN;
            set
            {
                if (sPointer != 0)
                    Bass.BASS_ChannelSetPosition(sPointer, Math.Max(Convert.ToInt64(Bass.BASS_ChannelGetLength(sPointer) * ((value < 0) ? 0d : (value > 1) ? 1d : value)) - 1, 0));
            }
        }

        /// <summary>
        /// Возвращает время воспроизведения
        /// </summary>
        public TimeSpan CurrentTime => (sPointer != 0) ? new TimeSpan((long)(Bass.BASS_ChannelBytes2Seconds(sPointer, Bass.BASS_ChannelGetPosition(sPointer)) * Math.Pow(10, 7))) : TimeSpan.Zero;

        /// <summary>
        /// Возвращает длину звуковой дорожки
        /// </summary>
        public TimeSpan TrackLength => (sPointer != 0) ? new TimeSpan((long)(Bass.BASS_ChannelBytes2Seconds(sPointer, Bass.BASS_ChannelGetLength(sPointer)) * Math.Pow(10, 7))) : TimeSpan.Zero;

        public SoundProcessing(IntPtr windowHandle)
        {
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, windowHandle))
                throw new Exception($"Ошибка библиотеки BASS. {Bass.BASS_ErrorGetCode().ToString()}");
        }
        public SoundProcessing() : this(IntPtr.Zero) { }

        /// <summary>
        /// Проверяет файл на корректность и открывает его
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public void OpenFile(string filePath)
        {
            if (sPointer != 0)
                Bass.BASS_StreamFree(sPointer);
            int stream = Bass.BASS_StreamCreateFile(filePath, 0, 0, BASSFlag.BASS_DEFAULT);
            if (stream == 0)
                throw new Exception($"Ошибка при открытии файла. {Bass.BASS_ErrorGetCode().ToString()}");
            sPointer = stream;
        }

        /// <summary>
        /// Запускает воспроизведение
        /// </summary>
        public void Play()
        {
            if (sPointer == 0)
                throw new NotSupportedException("Не назначен файл для проигрывания.");
            Bass.BASS_ChannelPlay(sPointer, false);
        }

        /// <summary>
        /// Приостанавливает воспроизведение
        /// </summary>
        public void Pause()
        {
            if (sPointer == 0)
                throw new NotSupportedException("Не назначен файл для проигрывания.");
            Bass.BASS_ChannelPause(sPointer);
        }

        /// <summary>
        /// Останавливает воспроизведение и устанавливает позицию в начало звуковой дорожки
        /// </summary>
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
