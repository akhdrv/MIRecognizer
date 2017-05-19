using System.Windows.Forms;

namespace MIRecognizer
{
    /// <summary>
    /// Окно с бегущей полосой загрузки и сообщением
    /// </summary>
    public partial class LoadingWindow : Form
    {
        public LoadingWindow(string loadingText)
        {
            InitializeComponent();
            this.label1.Text = loadingText;
        }
    }
}
