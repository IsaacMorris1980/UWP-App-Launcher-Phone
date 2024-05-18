﻿using appLauncher.Core.Helpers;
using appLauncher.Core.Pages;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using Application = Windows.UI.Xaml.Application;

namespace appLauncher
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public static ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;


        private bool isnetworkstatuschangedregistered = false;
        private NetworkStatusChangedEventHandler networkstatuschangedhandler;
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            App.Current.UnhandledException += App_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

        }

        private async void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("UnhandedExceptionmessage", e.Exception.Message);
            result.Add("StackTrace", e.Exception.StackTrace);
            result.Add("ExceptionSource", e.Exception.Source);
            result.Add("More Data", e.Exception.Data.ToString());

            try
            {

                string saveappsstring = JsonConvert.SerializeObject(result, Formatting.Indented);

                StorageFile appsFile = (StorageFile)await ApplicationData.Current.LocalFolder.CreateFileAsync("backgroundunhandlederrors.json", CreationCollisionOption.OpenIfExists);
                await FileIO.WriteTextAsync(appsFile, saveappsstring);


            }
            catch (Exception es)
            {

            }

        }

        private async void App_UnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("UnhandedExceptionmessage", e.Exception.Message);
            result.Add("StackTrace", e.Exception.StackTrace);
            result.Add("ExceptionSource", e.Exception.Source);
            result.Add("More Data", e.Exception.Data.ToString());
            try
            {

                string saveappsstring = JsonConvert.SerializeObject(result, Formatting.Indented);

                StorageFile appsFile = (StorageFile)await ApplicationData.Current.LocalFolder.CreateFileAsync("unhandlederrors.json", CreationCollisionOption.OpenIfExists);
                await FileIO.WriteTextAsync(appsFile, saveappsstring);


            }
            catch (Exception es)
            {

            }
        }


        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {

            try
            {


                //Extends view into status bar/title bar, depending on the device used.
                await SettingsHelper.LoadAppSettingsAsync();
                SettingsHelper.SetApplicationResources();



                Frame rootFrame = Window.Current.Content as Frame;



                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                if (rootFrame == null)
                {
                    // Create a Frame to act as the navigation context and navigate to the first page
                    rootFrame = new Frame();
                    rootFrame.NavigationFailed += OnNavigationFailed;
                    // Place the frame in the current Window
                    Window.Current.Content = rootFrame;
                    if (e.PreviousExecutionState != ApplicationExecutionState.Running)
                    {
                        rootFrame.Content = new FirstPage();
                        Window.Current.Content = rootFrame;
                    }
                }
                if (e.PrelaunchActivated == false)
                {
                    if (SettingsHelper.totalAppSettings.CanEnablePreLaunch)
                    {
                        TryEnablePrelaunch();
                    }
                    if (rootFrame.Content == null)
                    {
                        // When the navigation stack isn't restored navigate to the first page,
                        // configuring the new page by passing required information as a navigation
                        // parameter
                        rootFrame.Navigate(typeof(FirstPage), e.Arguments);
                    }
                    // Ensure the current window is active
                    Window.Current.Activate();
                }
            }
            catch (Exception es)
            {

            }
        }



        private void TryEnablePrelaunch()
        {
            Windows.ApplicationModel.Core.CoreApplication.EnablePrelaunch(true);
        }



        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            try
            {
                await PackageHelper.SaveCollectionAsync();
                await ImageHelper.SaveImageOrder();
                await SettingsHelper.SaveAppSettingsAsync();
            }
            catch (Exception es)
            {

            }

            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
