using appLauncher.Core.Helpers;
using appLauncher.Core.Model;

using Microsoft.Toolkit.Uwp.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;

using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace appLauncher.Core.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditApp : Page
    {
        private FinalTiles _tile;
        private ColorComboItem _color;
        private Color _logoColor;
        private Color _backColor;
        private Color _textColor;
        private int _tileOpacity = 0;
        public EditApp()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _tile = e.Parameter as FinalTiles;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TestApps.Items.Add(_tile);
            _color = SettingsHelper.MatchColor(_tile.BackColor);
            TileBackOpacity.Value = ReturnOpacity((int)_tile.BackColor.A);
            List<ColorComboItem> a = TileBackColor.Items.Cast<ColorComboItem>().ToList();
            TileBackColor.SelectedIndex = a.FindIndex(x => x.ColorName == _color.ColorName);
            _color = SettingsHelper.MatchColor(_tile.TextColor);
            TileTextOpacity.Value = ReturnOpacity((int)_tile.TextColor.A);
            List<ColorComboItem> b = TileTextColor.Items.Cast<ColorComboItem>().ToList();
            TileTextColor.SelectedIndex = b.FindIndex(x => x.ColorName == _color.ColorName);
            _color = SettingsHelper.MatchColor(_tile.LogoColor);
            LogoOpacity.Value = ReturnOpacity((int)_tile.LogoColor.A);
            List<ColorComboItem> d = TileLogoColor.Items.Cast<ColorComboItem>().ToList();
            TileLogoColor.SelectedIndex = d.FindIndex(x => x.ColorName == _color.ColorName);
        }

        private void TileBackColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tile.BackColor = (((ColorComboItem)((ComboBox)sender).SelectedItem).ColorName).ToColor();
            Preview_Tapped();
        }

        private void TileLogoColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tile.LogoColor = (((ColorComboItem)((ComboBox)sender).SelectedItem).ColorName).ToColor();
            Preview_Tapped();
        }

        private void TileTextColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tile.TextColor = (((ColorComboItem)((ComboBox)sender).SelectedItem).ColorName).ToColor();
            Preview_Tapped();

        }

        private void LogoOpacity_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            byte opacity = Convert.ToByte(((double)e.NewValue / 10) * 255);
            _tile.LogoColor = Color.FromArgb(opacity, _tile.LogoColor.R, _tile.LogoColor.G, _tile.LogoColor.B);
            Preview_Tapped();
        }

        private void TileBackOpacity_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            byte opacity = Convert.ToByte(((double)e.NewValue / 10) * 255);
            _tile.BackColor = Color.FromArgb(opacity, _tile.BackColor.R, _tile.BackColor.G, _tile.BackColor.B);
            Preview_Tapped();
        }

        private void TileTextOpacity_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            byte opacity = Convert.ToByte(((double)e.NewValue / 10) * 255);
            _tile.TextColor = Color.FromArgb(opacity, _tile.TextColor.R, _tile.TextColor.G, _tile.TextColor.B);
            Preview_Tapped();
        }

        private void Preview_Tapped()
        {
            TestApps.Items.Clear();
            TestApps.Items.Add(_tile);
        }

        private void SaveChanges_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            PackageHelper.Apps.UpdateApp(_tile);
        }
        private int ReturnOpacity(int opacity)
        {
            return (opacity / 255) * 10;
        }
    }
}
