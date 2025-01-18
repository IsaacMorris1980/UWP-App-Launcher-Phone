using appLauncher.Core.Model;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace appLauncher.Core.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllApps : Page
    {
        public AllApps()
        {
            this.InitializeComponent();
        }

        private void Folder_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ((RelativePanel)sender).ContextFlyout.ShowAt((RelativePanel)sender);
        }

        private void Folder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AppFolder folder = ((RelativePanel)sender).DataContext as AppFolder;
            FirstPage.navFrame.Navigate(typeof(FolderView),folder);
        }

        private void Apps_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ((RelativePanel)sender).ContextFlyout.ShowAt((RelativePanel)sender);
        }

        private async void Apps_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FinalTiles final = ((RelativePanel)sender).DataContext as FinalTiles;
             await final.Launch();
        }

        private void Editfolder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AppFolder folder = ((RelativePanel)sender).DataContext as AppFolder;
            FirstPage.navFrame.Navigate(typeof(EditFolder), folder);
        }

        private void FolderInfo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AppFolder folder = ((RelativePanel)sender).DataContext as AppFolder;
            FirstPage.navFrame.Navigate(typeof(FolderInfo), folder);
        }

        private void EditApp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FinalTiles final = ((RelativePanel)sender).DataContext as FinalTiles;
            FirstPage.navFrame.Navigate(typeof(EditApp), final);
        }

        private void AppInfo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FinalTiles final = ((RelativePanel)sender).DataContext as FinalTiles;
            FirstPage.navFrame.Navigate(typeof(AppInformation), final);
        }

        private void GridViewMain_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {

        }

        private void GridViewMain_DragOver(object sender, DragEventArgs e)
        {

        }

        private void GridViewMain_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {

        }

        private void GridViewMain_Drop(object sender, DragEventArgs e)
        {

        }

        private void GridViewMain_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void GridViewMain_Loaded(object sender, RoutedEventArgs e)
        {
            GridViewMain.Width = this.ActualWidth;
            GridViewMain.Height = this.ActualHeight;
        }

        private void Page_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            disableScrollViewer(GridViewMain);
        }
        private void disableScrollViewer(GridView gridView)
        {
            try
            {
                var border = (Border)VisualTreeHelper.GetChild(gridView, 0);
                var scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                scrollViewer.IsVerticalRailEnabled = false;
                scrollViewer.VerticalScrollMode = ScrollMode.Disabled;
                scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            }
            catch (Exception es)
            {
               // LoggingCrashesAsync(es).ConfigureAwait(false);
            }
        }
        public static int NumofRoworColumn(int objectSize, int sizeToFit)
        {
            int amount = 0;
            int size = objectSize;
            while (size <= sizeToFit)
            {
                amount += 1;
                size += objectSize;
            }
            return amount;
        }
    }
}
