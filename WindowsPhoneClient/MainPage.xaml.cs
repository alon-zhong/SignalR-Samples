using System.Threading;
using Microsoft.Phone.Controls;

namespace WindowsPhoneClient
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
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