using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MIRecognizer
{
    public partial class PlayerWindow : Form
    {
        /// <summary>
        /// Ссылка на экземпляр объекта класса для работы с аудио
        /// </summary>
        SoundProcessing sound;

        /// <summary>
        /// Ссылка на экземпляр объекта класса формы загрузки
        /// </summary>
        LoadingWindow loadingWindow;

        /// <summary>
        /// Ссылка на экземляр объекта класса формы для открытия файла
        /// </summary>
        OpenFileDialog openFileDialog;

        /// <summary>
        /// Ссылка на экземпляр объекта класса распознавания инструментов
        /// </summary>
        Recognizer recognizer;

        /// <summary>
        /// Массив с данными распознавания
        /// </summary>
        double[,] instrumentalInfo;

        // Поля для работы интерфейса программы
        //
        TimeSpan timerFlag = TimeSpan.Zero;
        bool mousePressed = false;
        int posX = 58;

        public PlayerWindow()
        {
            sound = new SoundProcessing(this.Handle);
            var mathematicaWaiter = new BackgroundWorker();
            mathematicaWaiter.DoWork += MathematicaInitialize;
            mathematicaWaiter.RunWorkerCompleted += MathematicaInitializeFinished;


            openFileDialog = new OpenFileDialog()
            {
                Filter = "Аудиофайлы (*.mp3, *.mp2, *.mp1, *.m1a, *.ogg, *.wav, *.aif, *.aiff, *.aifc)|" +
                "*.mp3;*.mp2;*.mp1;*.m1a;*.ogg;*.wav;*.aif;*.aiff;*.aifc"
            };
            openFileDialog.FileOk += OpenFileDialog_FileOk;


            InitializeComponent();


            loadingWindow = new LoadingWindow("Загрузка системы Mathematica");
            mathematicaWaiter.RunWorkerAsync();

            loadingWindow.ShowDialog(this);
        }

        /// <summary>
        /// Метод, вызывающийся про окончании фоновой загрузки класса-распознавателя
        /// </summary>
        private void MathematicaInitializeFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingWindow.Dispose();
            if (e.Error != null)
            {
                MessageBox.Show(this, "Система Wolfram Mathematica не установлена, либо не удалось найти путь к MathKernel.exe. Программа будет закрыта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
                recognizer = e.Result as Recognizer;
        }

        /// <summary>
        /// Метод для фоновой загрузки класса-распознавателя
        /// </summary>
        private void MathematicaInitialize(object sender, DoWorkEventArgs e)
        {
            var recognizer = new Recognizer();
            e.Result = recognizer;
        }

        /// <summary>
        /// Метод, вызывающийся после выбора пользователем файла.
        /// </summary>
        private void OpenFileDialog_FileOk(object sender, CancelEventArgs ev)
        {
            try
            {
                var fileName = (sender as OpenFileDialog).FileName;
                sound.OpenFile(fileName);

                var evaluationWaiter = new BackgroundWorker();
                evaluationWaiter.DoWork += ProceedFile;
                evaluationWaiter.RunWorkerCompleted += ProceedFileComplete;
                loadingWindow = new LoadingWindow("Распознавание инструментов");
                evaluationWaiter.RunWorkerAsync(fileName);
                loadingWindow.ShowDialog(this);

                trackLength.Text = sound.TrackLength.ToString(@"mm\:ss");
                fileNameLabel.Text = Path.GetFileName(fileName);
                (sender as OpenFileDialog).FileName = String.Empty;
                PlayPause();
            }
            catch (Exception)
            {
                MessageBox.Show(this, $"Неподдерживаемый формат файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Вызывается при завершении процесса распознавания муз. инструментов
        /// </summary>
        private void ProceedFileComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingWindow.Dispose();
            if (e.Error != null)
            {
                MessageBox.Show(this, "Соединение с MathKernel.exe прервано, либо версия Wolfram Mathematica ниже 11. Программа будет закрыта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
                instrumentalInfo = e.Result as double[,];
        }

        /// <summary>
        /// Метод для фонового распознавания муз. инструментов
        /// </summary>
        private void ProceedFile(object sender, DoWorkEventArgs e)
        {
            e.Result = recognizer.GetInstrumentalInfo(e.Argument as string);
        }

        /// <summary>
        /// Начинает или останавливает воспроизведение
        /// Если файл не открыт, открывает окно выбора
        /// </summary>
        private void PlayPause()
        {
            try
            {
                if (sound.Playing)
                {
                    sound.Pause();
                    sliderTimer.Stop();
                    SetPlayPauseImage(PlayPauseImage.Play);
                }
                else
                {
                    sound.Play();
                    sliderTimer.Start();
                    SetPlayPauseImage(PlayPauseImage.Pause);
                }
            }
            catch (Exception)
            {
                openFileDialog.ShowDialog(this);
            }
        }

        /// <summary>
        /// Перечисление, задающее стиль кнопки Паузы/Воспроизведения
        /// </summary>
        private enum PlayPauseImage { Pause, Play }

        /// <summary>
        /// Устанавливает стиль кнопки Пауза/Воспроизведение
        /// </summary>
        private void SetPlayPauseImage(PlayPauseImage image)
        {
            if (image == PlayPauseImage.Play)
            {
                playStopButton.Image = Properties.Resources.Play;
                slider.Image = Properties.Resources.SliderSteady;
            }
            if (image == PlayPauseImage.Pause)
            {
                playStopButton.Image = Properties.Resources.Pause;
                slider.Image = Properties.Resources.Slider;
            }
            playStopButton.Refresh();
        }

        /// <summary>
        /// Устанавливает положение каретки на полосе воспроизведения
        /// </summary>
        private void SetSliderPosition(double pos)
        {
            if(!double.IsNaN(pos))
                slider.Location = new Point((pos < 0) ? 58 : (pos > 1) ? 473 : Convert.ToInt32(58 + pos * 415), slider.Location.Y);
        }

        /// <summary>
        /// Остановить воспроизведение, передвинув каретку в ноль
        /// </summary>
        private void Stop()
        {
            try
            {
                sound.Stop();
                SetPlayPauseImage(PlayPauseImage.Play);
                SetSliderPosition(0);
                sliderTimer.Stop();
            }
            catch(Exception)
            {
                openFileDialog.ShowDialog(this);
            }
        }

        /// <summary>
        /// Показывает окно для открытия файла
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog(this);
        }

        /// <summary>
        /// Выходит из программы
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Начинает или оставливает воспроизведение
        /// </summary>
        private void playPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        /// <summary>
        /// Останавливает воспроизведение, передвинув каретку в ноль
        /// </summary>
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }

        /// <summary>
        /// Освобождает ресурсы и разрывает подключения.
        /// </summary>
        private void PlayerWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            sound.Dispose();
            openFileDialog.Dispose();
            recognizer.Dispose();
            Environment.Exit(0);
        }

        /// <summary>
        /// Начинает или останавливает воспроизведение
        /// </summary>
        private void playStopButton_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        /// <summary>
        /// Останавливает воспроизведение, передвинув каретку в ноль
        /// </summary>
        private void stopButton_Click(object sender, EventArgs e)
        {
            Stop();
        }

        /// <summary>
        /// Обновляет данные на форме
        /// </summary>
        private void sliderTimer_Tick(object sender, EventArgs e)
        {
            currentTime.Text = sound.CurrentTime.ToString(@"mm\:ss");

            if((int)sound.CurrentTime.TotalSeconds != (int)timerFlag.TotalSeconds)
            {
                timerFlag = sound.CurrentTime;
                var cs = (int)sound.CurrentTime.TotalSeconds/3;
                if (cs >= instrumentalInfo.GetLength(0))
                    cs = instrumentalInfo.GetLength(0) - 1;

                celloInd.BackColor = ColorFunction(instrumentalInfo[cs, 0]);
                //clarinetInd.BackColor = ColorFunction(instrumentalInfo[cs, 1]);
                fluteInd.BackColor = ColorFunction(instrumentalInfo[cs, 1]);
                acousticGuitarInd.BackColor = ColorFunction(instrumentalInfo[cs, 2]);
                electricGuitarInd.BackColor = ColorFunction(instrumentalInfo[cs, 3]);
                organInd.BackColor = ColorFunction(instrumentalInfo[cs, 4]);
                pianoInd.BackColor = ColorFunction(instrumentalInfo[cs, 5]);
                saxophoneInd.BackColor = ColorFunction(instrumentalInfo[cs, 6]);
                //trumpetInd.BackColor = ColorFunction(instrumentalInfo[cs, 8]);
                violinInd.BackColor = ColorFunction(instrumentalInfo[cs, 7]);
                voiceInd.BackColor = ColorFunction(instrumentalInfo[cs, 8]);
                drumsInd.BackColor = ColorFunction(instrumentalInfo[cs, 9]);
            }

            if (sound.CurrentTime.TotalMilliseconds != sound.TrackLength.TotalMilliseconds)
                if (!mousePressed)
                    SetSliderPosition(sound.CurrentPosition);
                else { }
            else
                Stop();
        }

        /// <summary>
        /// Функция цвета для alpha в промежутке [0, 1]. Чем alpha ближе к 1, тем цвет интенсивнее.
        /// </summary>
        private Color ColorFunction(double alpha)
        {
            alpha = (alpha > 1) ? 1 : (alpha < 0) ? 0 : alpha;
            return Color.FromArgb((int)(255 * (1 - 0.1 * Math.Pow(alpha, 2))),
                (int)(255 - 204 * alpha),
                (int)(255 - (610 / 3d) * alpha));
        }

        /// <summary>
        /// Метод для перетаскивания каретки на полосе воспроизведения
        /// </summary>
        public void Timeline_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePressed)
            {
                SetSliderPosition(e.X / 415d);

                if (Math.Abs(e.X - posX) > 1)
                {
                    sound.CurrentPosition = e.X / 415d;
                    posX = e.X;
                }

                timeline.Refresh();
                currentTime.Text = sound.CurrentTime.ToString(@"mm\:ss");
            }
        }

        /// <summary>
        /// Метод, вызываемый при отпускании левой кнопки мыши вне фокуса формы
        /// </summary>
        private void timeline_MouseCaptureChanged(object sender, EventArgs e)
        {
            mousePressed = false;
        }

        /// <summary>
        /// Метод, вызываемый при нажатии левой кнопки мыши.
        /// </summary>
        private void timeline_MouseDown(object sender, MouseEventArgs e)
        {
            mousePressed = true;
            SetSliderPosition(e.X / 415d);
            sound.CurrentPosition = e.X / 415d;
            posX = e.X;
        }

        /// <summary>
        /// Метод, вызываемый при отпускании левой кнопки мыши
        /// </summary>
        private void timeline_MouseUp(object sender, MouseEventArgs e)
        {
            mousePressed = false;
        }

        /// <summary>
        /// Метод, определяющий поведение при нажатии пользователем клавиш
        /// </summary>
        private void PlayerWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                PlayPause();


            if (e.KeyCode == Keys.Left)
            {
                sound.CurrentPosition = sound.CurrentPosition - (5 / sound.TrackLength.TotalSeconds);

                if (!sound.Playing)
                    SetSliderPosition(sound.CurrentPosition);
            }


            if (e.KeyCode == Keys.Right)
            {
                sound.CurrentPosition = sound.CurrentPosition + (5 / sound.TrackLength.TotalSeconds);

                if (!sound.Playing)
                    SetSliderPosition(sound.CurrentPosition);
            }
        }

        /// <summary>
        /// Открывает окно "о программе"
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var aw = new AboutWindow())
                aw.ShowDialog(this);
        }

        /// <summary>
        /// Вызывает очистку кэша
        /// </summary>
        private void clearCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Будет произведено удаление временных файлов", "Очистка кэша", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Recognizer.ClearCache();
        }
    }
}
