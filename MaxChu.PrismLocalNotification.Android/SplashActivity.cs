using Android.App;
using Android.Content;
using AndroidX.AppCompat.App;
using Plugin.LocalNotification;

namespace MaxChu.PrismLocalNotification.Droid {
	[Activity(Theme = "@style/MainTheme.Splash",
			  MainLauncher = true,
			  NoHistory = true)]
	public class SplashActivity : AppCompatActivity {
		// Launches the startup task
		protected override void OnResume() {
			base.OnResume();
			var data = Intent.GetStringExtra(NotificationCenter.ExtraReturnDataAndroid);
			var mainIntent = new Intent(Application.Context, typeof(MainActivity));

			mainIntent.SetFlags(ActivityFlags.SingleTop);
			if (!string.IsNullOrWhiteSpace(data)) {
				mainIntent.PutExtra(NotificationCenter.ExtraReturnDataAndroid, data);
			}

			StartActivity(mainIntent);
		}
	}
}
