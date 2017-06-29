using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace DemoEasyTables
{
    public partial class App : Application
    {
		private static MobileServiceClient _mobileServiceClient;

		public static MobileServiceClient MobileService
		{
			get
			{
				if (_mobileServiceClient == null)
					_mobileServiceClient = new MobileServiceClient("http://demonetconfar2017.azurewebsites.net");
				return _mobileServiceClient;
			}
		}

        public App()
        {
            InitializeComponent();

            MainPage = new DemoEasyTablesPage();
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
}
