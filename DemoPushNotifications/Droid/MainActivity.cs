using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase;
using WindowsAzure.Messaging;

namespace DemoPushNotifications.Droid
{
    [Activity(Label = "DemoPushNotifications.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

			var options = new FirebaseOptions.Builder()
					.SetApplicationId("734317879202")
					.SetApiKey("AIzaSyCXMYQ1s6dt-wdz6mgR5Nf92lTy4VgG_ho")
					.SetGcmSenderId("734317879202")
					.Build();

			FirebaseApp.InitializeApp(this, options);

            LoadApplication(new App());

			NotificationHub hub = new NotificationHub.CreateClientFromConnectionString("DemoNETConfAR2017", "Endpoint=sb://demonetconfar2017.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=SaqDzOhq8iKuAL+kEO07wZ8AUWTn/bO/YmoFP+6+pZo=",
													  Android.App.Application.Context);

			await hub.SendGcmNativeNotificationAsync("{ \"data\" : {\"message\":\"Hello from Azure!\"}}");
        }
    }
}
