using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Plugin.LocalNotification;
using Prism;
using Prism.Ioc;

namespace MaxChu.PrismLocalNotification.Droid {
	[Activity(Theme = "@style/MainTheme",
			  LaunchMode = LaunchMode.SingleTask,
			  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
		protected override void OnCreate(Bundle savedInstanceState) {
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			// Must create a Notification Channel when API >= 26
			// you can created multiple Notification Channels with different names.
			NotificationCenter.CreateNotificationChannel();

			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			LoadApplication(new App(new AndroidInitializer()));

			NotificationCenter.NotifyNotificationTapped(Intent);
		}

		protected override void OnNewIntent(Intent intent) {
			NotificationCenter.NotifyNotificationTapped(intent);
			base.OnNewIntent(intent);
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults) {
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}

	public class AndroidInitializer : IPlatformInitializer {
		public void RegisterTypes(IContainerRegistry containerRegistry) {
			// Register any platform specific implementations
		}
	}
}

