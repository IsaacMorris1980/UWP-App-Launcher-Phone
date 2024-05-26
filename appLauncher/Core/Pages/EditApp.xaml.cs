using appLauncher.Core.Model;

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

        }

        private void TileBackColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TileLogoColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TileTextColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LogoOpacity_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {

        }

        private void TileBackOpacity_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {

        }

        private void TileTextOpacity_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {

        }

        private void Preview_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {

        }

        private void SaveChanges_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {

        }
    }
}
