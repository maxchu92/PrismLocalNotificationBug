using MaxChu.PrismLocalNotification.ViewModels;
using MaxChu.PrismLocalNotification.Views;
using Plugin.LocalNotification;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MaxChu.PrismLocalNotification {
	public partial class App {
		public App(IPlatformInitializer initializer)
			: base(initializer) {
		}

		protected override async void OnInitialized() {
			InitializeComponent();

			// Local Notification tap event listener
			NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;

			await NavigationService.NavigateAsync("NavigationPage/MainPage");
		}
		private void OnLocalNotificationTapped(NotificationTappedEventArgs e) {
			Device.BeginInvokeOnMainThread(async () => {
				await Application.Current.MainPage.DisplayAlert("Notification Tapped!", e.Data, "Done");
			});
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry) {
			containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

			containerRegistry.RegisterForNavigation<NavigationPage>();
			containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
		}
	}
}
