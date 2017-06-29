using System;
using Android.App;
using Firebase.Iid;
using WindowsAzure.Messaging;

namespace DemoPushNotifications.Droid
{
	[Service]
	[IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
	public class MyFirebaseIIDService : FirebaseInstanceIdService
	{
		const string TAG = "MyFirebaseIIDService";
		public override void OnTokenRefresh()
		{
			var refreshedToken = FirebaseInstanceId.Instance.Token;
			SendRegistrationToServer(refreshedToken);
		}
		void SendRegistrationToServer(string token)
		{
			NotificationHub hub = new NotificationHub("DemoNETConfAR2017", "Endpoint=sb://demonetconfar2017.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=SaqDzOhq8iKuAL+kEO07wZ8AUWTn/bO/YmoFP+6+pZo=",
													  Android.App.Application.Context);

			hub.UnregisterAll(token);
			string[] tags = new string[] { "prueba" };
			hub.Register(token, tags);
		}
	}
}
