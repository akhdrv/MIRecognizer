using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wolfram.NETLink;

namespace MIRecognizer
{
    class PlayerPresenter : IPresenter
    {
        private const double refreshInterval = 100;
        private IPlayerView playerView;
        private PlayerModel model;
        private Timer refresher;
        private OpenFileDialog openFileDialog;
        private double previousTimelinePosition;

        public PlayerPresenter(IPlayerView view, PlayerModel model)
        {
            playerView = view;
            this.model = model;
            refresher = new Timer() { Interval = 100 };

            openFileDialog = new OpenFileDialog()
            {
                Filter = Properties.Settings.Default.FileFilter
            };
            #region Event Bindings
            playerView.AboutClicked += (s, e) => new AboutWindow().ShowDialog(playerView);
            playerView.ClearCacheClicked += (s, e) =>
            {
                if (MessageBox.Show(playerView, Properties.Settings.Default.CacheRemovalProceed, 
                    Properties.Settings.Default.CacheRemoval, MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Question) == DialogResult.OK)
                    model.ClearCache();
            };
            playerView.KeyDown += (s, e) => KeyDown(e);
            playerView.OpenFileClicked += (s, e) => openFileDialog.ShowDialog(playerView);
            playerView.PlayPauseInvoked += (s, e) => PlayPause();
            playerView.StopInvoked += (s, e) => Stop();
            openFileDialog.FileOk += FileSelected;
            refresher.Tick += (s, e) => UpdateView();
            #endregion
            refresher.Start();
        }

        private void FileSelected(object sender, CancelEventArgs e)
        {
            try
            {
                using (var loadingWindow = new LoadingWindow(
                    Properties.Settings.Default.RecognitionProcessing))
                {
                    loadingWindow.Load += async (s, ev) =>
                    {
                        try
                        {
                            await Task.Run(() => model.OpenFile(openFileDialog.FileName));
                        }
                        catch (MathLinkException)
                        {
                            MessageBox.Show(playerView, Properties.Settings.Default.MathLinkCorrupted,
                                Properties.Settings.Default.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            playerView.Close();
                        }
                        finally
                        {
                            loadingWindow.Close();
                        }
                    };
                    loadingWindow.ShowDialog(playerView);
                }
                playerView.SetFileInfo(model.TrackName, model.TrackLength);
                model.Play();
            }
            catch (Exception)
            {
                MessageBox.Show(playerView, Properties.Settings.Default.UnsupportedFile, 
                    Properties.Settings.Default.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        public void UpdateView()
        {
            if (model.Ready)
            {
                playerView.SetPlaybackState(model.Playing);
                if (playerView.TimelinePushed)
                    if (playerView.PlaybackPosition != previousTimelinePosition)
                    {
                        model.PlaybackPosition = playerView.PlaybackPosition;
                        previousTimelinePosition = playerView.PlaybackPosition;
                    }
                    else { }
                else
                {
                    playerView.PlaybackPosition = model.PlaybackPosition;
                    previousTimelinePosition = model.PlaybackPosition;
                }
                playerView.SetCurrentProbabilities(model.GetCurrentProbabilities());
            }
        }

        private void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                PlayPause();
        }

        private void Stop()
        {
            if (model.Ready)
                model.Stop();
            else
                openFileDialog.ShowDialog(playerView);
        }

        private void PlayPause()
        {
            if (model.Ready)
                if (model.Playing)
                    model.Pause();
                else
                    model.Play();
            else
                openFileDialog.ShowDialog(playerView);
        }

        public void BindModel()
        {
            using (var loadingWindow = new LoadingWindow(Properties.Settings.Default.MathLoading))
            {
                loadingWindow.Load += async (s, e) =>
                {
                    try
                    {
                        await Task.Run(() => model.Initialize());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(playerView, Properties.Settings.Default.MathLinkInitFail,
                            Properties.Settings.Default.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        playerView.Close();
                    }
                    finally
                    {
                        loadingWindow.Close();
                    }
                };
                loadingWindow.ShowDialog(playerView);
            }
        }
        public void Dispose()
        {
            refresher?.Dispose();
            model?.Dispose();
        }
    }
}
