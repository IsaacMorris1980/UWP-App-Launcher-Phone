using appLauncher.Core.Helpers;
using appLauncher.Core.Model;

using System.Linq;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace appLauncher.Core.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppInformation : Page

    {
        private FinalTiles _tiles;
        public AppInformation()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _tiles = e.Parameter as FinalTiles;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Favorited.IsChecked = _tiles.Favorite;
        }

        private void Favorited_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _tiles.Favorite = (bool)Favorited.IsChecked;
            var a = PackageHelper.Apps.GetOriginalCollection().ToList();
            var b = a.OfType<FinalTiles>().ToList();
            if (b.Any(x => x.Name == _tiles.Name))
            {
                b[b.IndexOf(b.First(x => x.Name == _tiles.Name))] = _tiles;
            }

        }


        private void Favorited_Unchecked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _tiles.Favorite = (bool)Favorited.IsChecked;
            var a = PackageHelper.Apps.GetOriginalCollection().ToList();
            var b = a.OfType<FinalTiles>().ToList();
            if (b.Any(x => x.Name == _tiles.Name))
            {
                b[b.IndexOf(b.First(x => x.Name == _tiles.Name))] = _tiles;
            }
        }

    }
}
