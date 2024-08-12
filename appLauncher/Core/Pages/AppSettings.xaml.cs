using appLauncher.Core.Helpers;
using appLauncher.Core.Model;

using Microsoft.Toolkit.Uwp.Helpers;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace appLauncher.Core.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppSettings : Page
    {
        public AppSettings()
        {
            this.InitializeComponent();
        }

        private void ApplicationTextColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingsHelper.totalAppSettings.AppForgroundColor = (((ColorComboItem)((ComboBox)sender).SelectedItem).ColorName).ToColor();
        }

        private void ApplicationBackColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingsHelper.totalAppSettings.AppBackgroundColor = (((ColorComboItem)((ComboBox)sender).SelectedItem).ColorName).ToColor();
        }

        private void ApplicationTextOpacity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Color f = Color.FromArgb(Convert.ToByte((((double)e.NewValue / 10) * 255)), SettingsHelper.totalAppSettings.AppForgroundColor.R, SettingsHelper.totalAppSettings.AppForgroundColor.G, SettingsHelper.totalAppSettings.AppForgroundColor.B);
            SettingsHelper.totalAppSettings.AppForgroundColor = f;
        }

        private void ApplicationBackOpacity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Color f = Color.FromArgb(Convert.ToByte((((double)e.NewValue / 10) * 255)), SettingsHelper.totalAppSettings.AppBackgroundColor.R, SettingsHelper.totalAppSettings.AppBackgroundColor.G, SettingsHelper.totalAppSettings.AppBackgroundColor.B);
            SettingsHelper.totalAppSettings.AppBackgroundColor = f;
        }
        private void SaveSettings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int time;
            int.TryParse(ChangeTime.Text, out time);
            SettingsHelper.totalAppSettings.ImageRotationTime = (time <= 0) ? TimeSpan.FromSeconds(15) : TimeSpan.FromSeconds(time);
            SettingsHelper.SetApplicationResources();
            SettingsHelper.SaveAppSettingsAsync().ConfigureAwait(true);
        }
    }
}
