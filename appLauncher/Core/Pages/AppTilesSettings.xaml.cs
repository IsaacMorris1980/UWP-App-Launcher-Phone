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
    public sealed partial class AppTilesSettings : Page
    {
        private bool allapps = false;
        private FinalTiles selectedapp;
        private string sectionofapp;
        private string Appscolor;
        private string apptextcolor;
        private string appbackcolor;
        private string AppToggleTip = "Change settings for all app or specific app";
        public AppTilesSettings()
        {
            this.InitializeComponent();
        }

        private void TileLogoColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedapp.LogoColor = (((ColorComboItem)((ComboBox)sender).SelectedItem).ColorName).ToColor();
        }

        private void LogoOpacity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Color c = Color.FromArgb(Convert.ToByte((((double)e.NewValue / 10) * 255)), selectedapp.LogoColor.R, selectedapp.LogoColor.G, selectedapp.LogoColor.B);
            selectedapp.LogoColor = c;
        }

        private void TileBackColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedapp.BackColor = (((ColorComboItem)((ComboBox)sender).SelectedItem).ColorName).ToColor();
        }

        private void TileBackOpacity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Color backcolor = Color.FromArgb(Convert.ToByte((((double)e.NewValue / 10) * 255)), selectedapp.BackColor.R, selectedapp.BackColor.G, selectedapp.BackColor.B);
            selectedapp.BackColor = backcolor;
        }

        private void TileTextColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedapp.TextColor = (((ColorComboItem)((ComboBox)sender).SelectedItem).ColorName).ToColor();
        }

        private void TileTextOpacity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Color f = Color.FromArgb(Convert.ToByte(((double)e.NewValue / 10) * 255), selectedapp.TextColor.R, selectedapp.TextColor.G, selectedapp.TextColor.B);
            selectedapp.TextColor = f;
        }

        private void Preview_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TestApps.Items.Clear();
            TestApps.Items.Add(selectedapp);
        }

        private void SaveChanges_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (allapps)
            {
                for (int i = 0; i < PackageHelper.Apps.GetOriginalCollection().Count; i++)
                {
                    ((FinalTiles)PackageHelper.Apps.GetOriginalCollection()[i]).TextColor = selectedapp.TextColor;
                    ((FinalTiles)PackageHelper.Apps.GetOriginalCollection()[i]).LogoColor = selectedapp.LogoColor;
                    ((FinalTiles)PackageHelper.Apps.GetOriginalCollection()[i]).BackColor = selectedapp.BackColor;
                }
                ResetAppTilePage();
                return;
            }
            int appselected = PackageHelper.Apps.IndexOf(PackageHelper.Apps.FirstOrDefault(x => x.Name == selectedapp.Name));
            if (appselected > -1)
            {
                PackageHelper.Apps.GetOriginalCollection()[appselected] = selectedapp;
            }
            ResetAppTilePage();
        }
        private void ResetAppTilePage()
        {
            Preview.IsHitTestVisible = false;
            SaveChanges.IsHitTestVisible = false;
            TileLogoColor.IsHitTestVisible = false;
            TileTextColor.IsHitTestVisible = false;
            TileBackColor.IsHitTestVisible = false;
            TileBackOpacity.IsHitTestVisible = false;
            LogoOpacity.IsHitTestVisible = false;
            TileTextOpacity.IsHitTestVisible = false;
            TestApps.Items.Clear();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            selectedapp = PackageHelper.Apps.GetOriginalCollection().OfType<FinalTiles>().FirstOrDefault();
        }

        private void Appslist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Appslist.SelectedIndex > -1)
            {
                selectedapp = (FinalTiles)Appslist.SelectedItem;
            }
        }

        private void AppSettings_Toggled(object sender, RoutedEventArgs e)
        {
            allapps = ((ToggleSwitch)sender).IsOn;
            Appslist.Visibility = (((ToggleSwitch)sender).IsOn==true)?Visibility.Collapsed:Visibility.Visible; 
        }
    }
}