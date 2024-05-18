using appLauncher.Core.Helpers;
using appLauncher.Core.Model;
using appLauncher.Core.Pages;

using System.Collections.ObjectModel;
using System.Linq;

using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace appLauncher.Core.UserControls
{
    public sealed partial class EllipseButton : UserControl
    {
        private ObservableCollection<PageIndicators> _pageIndicators = new ObservableCollection<PageIndicators>();

        public EllipseButton()
        {
            this.InitializeComponent();
            _pageIndicators = FirstPage.pages;

        }



        private void UserControl_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (_pageIndicators.Count() > 1)
            {
                HoldButtons.ItemsSource = _pageIndicators.ToList();
                return;
            }
            HoldButtons.ItemsSource = null;
            HoldButtons.Background = new SolidColorBrush(Colors.Red);
            Bindings.Update();

        }

        private void Pages_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Button selbutton = (Button)sender;
            foreach (var item in FirstPage.pages)
            {
                if (item.PageNum == int.Parse(selbutton.Tag.ToString()))
                {
                    FirstPage.showMessage.Show($"Selected {item.Tip}", 1500);
                    PackageHelper.Apps.ChangePage(int.Parse(selbutton.Tag.ToString()));
                    item.Selected = true;
                    SettingsHelper.totalAppSettings.LastPageNumber = int.Parse(selbutton.Tag.ToString());

                }
                else
                {
                    item.Selected = false;
                }

            }
            Bindings.Update();

        }
    }
}
