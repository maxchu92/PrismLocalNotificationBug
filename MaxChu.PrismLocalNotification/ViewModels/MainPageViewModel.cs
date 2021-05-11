using Plugin.LocalNotification;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxChu.PrismLocalNotification.ViewModels {
	public class MainPageViewModel : ViewModelBase {

		private DelegateCommand _showNotificationCommand;
		public DelegateCommand ShowNotificationCommand => _showNotificationCommand ?? (_showNotificationCommand = new DelegateCommand(ExecuteShowNotificationCommand));

		protected void ExecuteShowNotificationCommand() {
			var notification = new NotificationRequest {
				NotificationId = 100,
				Title = "Test",
				Description = "Test Description",
				ReturningData = "Dummy data", // Returning data when tapped on notification.
				NotifyTime = DateTime.Now.AddSeconds(1) // Used for Scheduling local notification, if not specified notification will show immediately.
			};
			NotificationCenter.Current.Show(notification);
		}
		public MainPageViewModel(INavigationService navigationService)
			: base(navigationService) {
			Title = "Main Page";
		}
	}
}
