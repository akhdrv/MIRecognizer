using System;
using System.Windows.Forms;

namespace MIRecognizer
{
    interface IView
    {
        void Close();
    }

    interface IPresenter : IDisposable
    {
        void BindModel();
    }

    interface IPlayerView : IView, IWin32Window
    {
        event EventHandler PlayPauseInvoked, StopInvoked,
            ClearCacheClicked, AboutClicked,
            OpenFileClicked;
        event KeyEventHandler KeyDown;
        void SetCurrentProbabilities(InstrumentalProbabilities ip);
        void SetFileInfo(string name, TimeSpan length);
        void Reset();
        void SetPlaybackState(bool playing);
        bool TimelinePushed { get; }
        double PlaybackPosition { get; set; }
    }
}
