using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SilverlightClient
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            Client client = new Client();
            client.Context = SynchronizationContext.Current;
            client.Page = this;
            client.RunAsync();
        }        
    }
}
