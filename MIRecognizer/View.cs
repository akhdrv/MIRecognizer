using System;
using System.Drawing;
using System.Windows.Forms;

namespace MIRecognizer
{
    public partial class View : Form, IPlayerView
    {
        private IPresenter presenter;
        private TimeSpan trackLength;
        private bool playing;

        public event EventHandler PlayPauseInvoked;
        public event EventHandler StopInvoked;
        public event EventHandler ClearCacheClicked;
        public event EventHandler AboutClicked;
        public event EventHandler OpenFileClicked;

        public bool TimelinePushed { get; private set; }
        public View()
        {
            InitializeComponent();
            presenter = new PlayerPresenter(this, new PlayerModel(this.Handle));

            #region Event Bindings
            Load += (s, e) => {
                Reset();
                presenter.BindModel();
            };
            FormClosed += (s, e) => presenter.Dispose();
            openToolStripMenuItem.Click += (s, e) => OpenFileClicked.Invoke(s, e);
            clearCacheToolStripMenuItem.Click += (s, e) => ClearCacheClicked.Invoke(s, e);
            playPauseToolStripMenuItem.Click += (s, e) => PlayPauseInvoked.Invoke(s, e);
            playPauseButton.Click += (s, e) => PlayPauseInvoked.Invoke(s, e);
            stopButton.Click += (s, e) => StopInvoked.Invoke(s, e);
            stopToolStripMenuItem.Click += (s, e) => StopInvoked.Invoke(s, e);
            aboutToolStripMenuItem.Click += (s, e) => AboutClicked.Invoke(s, e);
            exitToolStripMenuItem.Click += (s, e) => Close();

            timeline.MouseMove += (s, e) =>
            {
                if (TimelinePushed)
                    PlaybackPosition = Math.Min(timeline.Width - slider.Width, Math.Max(e.X, 0)) /
                        Convert.ToDouble(timeline.Width - slider.Width);
            };
            timeline.MouseDown += (s, e) =>
            {
                TimelinePushed = true;
                PlaybackPosition = Math.Min(timeline.Width - slider.Width, Math.Max(e.X, 0)) /
                    Convert.ToDouble(timeline.Width - slider.Width);
            };
            timeline.MouseUp += (s, e) => TimelinePushed = false;
            timeline.MouseCaptureChanged += (s, e) => TimelinePushed = false;
            #endregion
        }

        public void SetPlaybackState(bool playing)
        {
            if (playing ^ this.playing)
            {
                if (playing)
                {
                    playPauseButton.Image = Properties.Resources.Pause;
                    slider.Image = Properties.Resources.Slider;
                }
                else
                {
                    playPauseButton.Image = Properties.Resources.Play;
                    slider.Image = Properties.Resources.SliderSteady;
                }
                playPauseButton.Refresh();
                slider.Refresh();
                this.playing = playing;
            }
        }

        public double PlaybackPosition
        {
            get => (slider.Location.X - timeline.Location.X) /
                Convert.ToDouble(timeline.Width - slider.Width);
            set
            {
                slider.Location = new Point(
                    Convert.ToInt32(value * (timeline.Width - slider.Width))
                    + timeline.Location.X, slider.Location.Y);
                currentTime.Text = TimeSpan.FromMilliseconds(
                    trackLength.TotalMilliseconds * value).ToString(@"mm\:ss");
                timeline.Refresh();
            }
        }

        private Color ColorFunction(double intensity)
        {
            intensity = (intensity > 1) ? 1 : (intensity < 0) ? 0 : intensity;
            return Color.FromArgb((int)(255 * (1 - 0.1 * Math.Pow(intensity, 2))),
                (int)(255 - 204 * intensity),
                (int)(255 - (610 / 3d) * intensity));
        }

        public void SetCurrentProbabilities(InstrumentalProbabilities ip)
        {
            celLabel.BackColor = ColorFunction(ip.Cello);
            vioLabel.BackColor = ColorFunction(ip.Violin);
            fluLabel.BackColor = ColorFunction(ip.Flute);
            saxLabel.BackColor = ColorFunction(ip.Sax);
            gelLabel.BackColor = ColorFunction(ip.ElGuitar);
            gacLabel.BackColor = ColorFunction(ip.AcGuitar);
            orgLabel.BackColor = ColorFunction(ip.Organ);
            piaLabel.BackColor = ColorFunction(ip.Piano);
            voiLabel.BackColor = ColorFunction(ip.Voice);
            druLabel.BackColor = ColorFunction(ip.Drums);
        }

        public void SetFileInfo(string name, TimeSpan length)
        {
            trackLengthLabel.Text = length.ToString(@"mm\:ss");
            trackLength = length;
            fileNameLabel.Text = name;
            timeline.Enabled = true;
        }

        public void Reset()
        {
            timeline.Enabled = false;
            trackLengthLabel.Text = "00:00";
            fileNameLabel.Text = String.Empty;
            PlaybackPosition = 0;
        }
    }
}
