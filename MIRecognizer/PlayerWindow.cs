using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIRecognizer
{
    public partial class PlayerWindow : Form
    {
        SoundProcessing sound;
        OpenFileDialog openFileDialog;
        bool mousePressed = false;
        int posX = 58;
        public PlayerWindow()
        {
            InitializeComponent();
            sound = new SoundProcessing(this.Handle);
            openFileDialog = new OpenFileDialog()
            {
                Filter = "Аудиофайлы (*.mp3, *.mp2, *.mp1, *.m1a, *.ogg, *.wav, *.aif, *.aiff, *.aifc)|" +
                "*.mp3;*.mp2;*.mp1;*.m1a;*.ogg;*.wav;*.aif;*.aiff;*.aifc"
            };
            openFileDialog.FileOk += OpenFileDialog_FileOk;
        }

        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                if (!e.Cancel)
                {
                    sound.OpenFile((sender as OpenFileDialog).FileName);
                    trackLength.Text = sound.TrackLength.ToString(@"mm\:ss");
                    PlayPause();
                }
            }
            catch(Exception)
            {
                MessageBox.Show(this, "Неподдерживаемый формат файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private enum PlayPauseImage { Pause, Play }

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

        private void SetSliderPosition(double pos)
        {
            if(!double.IsNaN(pos))
                slider.Location = new Point((pos < 0) ? 58 : (pos > 1) ? 473 : Convert.ToInt32(58 + pos * 415), slider.Location.Y);
        }

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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void PlayerWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            sound.Dispose();
        }

        private void playStopButton_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void sliderTimer_Tick(object sender, EventArgs e)
        {
            currentTime.Text = sound.CurrentTime.ToString(@"mm\:ss");
            if (sound.CurrentTime.TotalMilliseconds != sound.TrackLength.TotalMilliseconds)
                if (!mousePressed)
                    SetSliderPosition(sound.CurrentPosition);
                else { }
            else
                Stop();
        }

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

        private void timeline_MouseCaptureChanged(object sender, EventArgs e)
        {
            mousePressed = false;
        }

        private void timeline_MouseDown(object sender, MouseEventArgs e)
        {
            mousePressed = true;
            SetSliderPosition(e.X / 415d);
            sound.CurrentPosition = e.X / 415d;
            posX = e.X;
        }

        private void timeline_MouseUp(object sender, MouseEventArgs e)
        {
            mousePressed = false;
        }

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
    }
}
