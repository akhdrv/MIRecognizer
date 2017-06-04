using System.Windows.Forms;
using System.Threading.Tasks;

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
            label1.Text = loadingText;
        }
    }
}
