using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace DemoTwitterAuth.Droid
{
    [Activity(Label = "DemoTwitterAuth.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAuthenticate
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

			// Inicializa el autenticador
			App.Init((IAuthenticate)this);

            LoadApplication(new App());
        }

		// Define a authenticated user.
		private MobileServiceUser user;

		public async Task<bool> Authenticate()
		{
			var success = false;
	
			user = await App.MobileService.LoginAsync(this,
							 MobileServiceAuthenticationProvider.Twitter);
			if (user != null)
			{
                App.userId = user.UserId;
				success = true;
			}

			return success;
		}
    }
}
