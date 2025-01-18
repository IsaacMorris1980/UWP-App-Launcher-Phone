using appLauncher.Core.Extensions;
using appLauncher.Core.Helpers;
using appLauncher.Core.Interfaces;
using appLauncher.Core.Model;

using System.Collections.Generic;
using System.Linq;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace appLauncher.Core.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditFolder : Page
    {
        private AppFolder _createEditFolder;
        private List<FinalTiles> _tiles = new List<FinalTiles>();
        private FinalTiles _selectedApp;

        public EditFolder()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _createEditFolder = e.Parameter as AppFolder;
            _tiles = PackageHelper.Apps.GetOriginalCollection().OfType<FinalTiles>().ToList();
            titleTextBlock.Text = (PackageHelper.Apps.GetOriginalCollection().OfType<AppFolder>().Any(x => x.Name == _createEditFolder.Name)) ? $"Edit \"{_createEditFolder.Name}\" Folder" : $"Create \"{_createEditFolder.Name}\" Folder";

        }

        private void AppsinFolders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.UnloadObject(addApp);
            this.FindName("removeApp");
            _selectedApp = (FinalTiles)AppsinFolders.SelectedItem;
        }

        private void SaveButton_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var folders = PackageHelper.Apps.OfType<AppFolder>().ToList();
            var apps = PackageHelper.Apps.OfType<FinalTiles>().ToList();
            List<IApporFolder> combinedlist = new List<IApporFolder>();
            folders.Add(_createEditFolder);
            apps.Clear();
            apps.AddRange(_tiles);
            combinedlist.AddRange(folders);
            combinedlist.AddRange(apps);
            PackageHelper.Apps = new AppPaginationObservableCollection(combinedlist.OrderBy(x => x.Name));

        }

        private void AllTiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.FindName("addApp");
            this.UnloadObject(removeApp);
            _selectedApp = (FinalTiles)AllTiles.SelectedItem;
        }

        private void removeApp_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            this.UnloadObject(addApp);
            _selectedApp = (FinalTiles)AppsinFolders.SelectedItem;
            _createEditFolder.FolderApps.Remove(_selectedApp);
            if (_createEditFolder.FolderApps.Count() <= 0)
            {
                this.UnloadObject(AppsinFolders);
                this.UnloadObject(InFolder);
            }
            _tiles.Add(_selectedApp);
            Bindings.Update();
        }

        private void addApp_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _createEditFolder.FolderApps.Add(_selectedApp);
            this.FindName("AppsinFolders");
            this.FindName("InFolder");
            _tiles.Remove(x => x.FullName == _selectedApp.FullName);
            AllTiles.ItemsSource = _tiles;
            Bindings.Update();
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (_createEditFolder.FolderApps.Count() > 0)
            {
                this.FindName("InFolder");
                this.FindName("AppsinFolders");
                AppsinFolders.ItemsSource = _createEditFolder.FolderApps;
            }
            else
            {
                this.UnloadObject(InFolder);
                this.UnloadObject(AppsinFolders);
            }
            if (PackageHelper.Apps.GetOriginalCollection().OfType<FinalTiles>().Count() > 0)
            {
                this.FindName("AllTilesText");
                this.FindName("AllTiles");
                AllTiles.ItemsSource = _tiles;
            }
            else
            {
                this.UnloadObject(AllTiles);
                this.UnloadObject(AllTilesText);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
