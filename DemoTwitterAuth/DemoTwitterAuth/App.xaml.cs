using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace DemoTwitterAuth
{
    public partial class App : Application
    {
		public static IAuthenticate Authenticator { get; private set; }
        public static string userId = string.Empty;

		public static MobileServiceClient MobileService =
			new MobileServiceClient(
			"https://demonetconfar2017.azurewebsites.net"
		);

		public static void Init(IAuthenticate authenticator)
		{
			Authenticator = authenticator;
		}

        public App()
        {
            InitializeComponent();

            MainPage = new DemoTwitterAuthPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

	public interface IAuthenticate
	{
		Task<bool> Authenticate();
	}
}
