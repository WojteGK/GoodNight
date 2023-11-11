using Plugin.LocalNotification;
using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace GoodNight.Views
{
    public partial class MainPage : ContentPage
    {
        TimeSpan selectedTime;
        public MainPage()
        {           
            InitializeComponent();

            timePicker.Unfocused += (sender, e) =>
            {
                selectedTime = timePicker.Time;

                if (selectedTime.ToString().Substring(0) == "0")
                    time.Text = selectedTime.ToString("h\\:mm");
                else
                    time.Text = selectedTime.ToString("hh\\:mm");
            };
        }

        void SetAlarmButton_OnClick(object sender, EventArgs e)
        {
            timePicker.Focus();
        }
        async void Test(object sender, EventArgs e)
        {
            if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
            {
                await LocalNotificationCenter.Current.RequestNotificationPermission();
            }

            var notification = new NotificationRequest
            {
                NotificationId = 100,
                Title = "Test",
                Description = "Test Description",
                ReturningData = "Dummy data", 
                Schedule =
                {
                     NotifyTime = DateTime.Now.AddSeconds(5) 
                },
                Android =
                {
                    Priority = Plugin.LocalNotification.AndroidOption.AndroidPriority.Max,
                },
                Sound = DeviceInfo.Platform == DevicePlatform.Android ? "sound" : "sound.mp3",
            };
            await LocalNotificationCenter.Current.Show(notification);
        }
    }
}