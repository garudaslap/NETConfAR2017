using System;
using Android.App;
using Android.Content;
using Firebase.Messaging;

namespace DemoPushNotifications.Droid
{
	[Service, IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
	public class MyFirebaseListenerService : FirebaseMessagingService
	{
		private const string PushNotificationTitle = "Demo NET Conf AR";
		private const string PushNotificationResponseMessageField = "message";

		public override void OnMessageReceived(RemoteMessage message)
		{
			base.OnMessageReceived(message);
			var context = Android.App.Application.Context;

			// Instantiate the builder and set notification elements:
			Notification.Builder builder = new Notification.Builder(context)
				.SetContentTitle(PushNotificationTitle)
				.SetContentText(message.Data[PushNotificationResponseMessageField])
                .SetSmallIcon(Resource.Drawable.icon);

			// Build the notification:
			Notification notification = builder.Build();

			// Get the notification manager:
			NotificationManager notificationManager =
				GetSystemService(Context.NotificationService) as NotificationManager;

			// Publish the notification:
			int notificationId = new Random().Next(0, 10000);
			notificationManager.Notify(notificationId, notification);
		}
	}
}
