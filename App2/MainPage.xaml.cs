using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
           // SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
        }


        //protected async override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        //    base.OnNavigatedTo(e);
        //}

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            HamburgerButton.Content = "&#xE764;";
        }


        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
           

        }



        private void ShareListBoxItem_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            framek.Navigate(typeof(AboutPage));
        }

        private void FavoritesListBoxItem_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            framek.Navigate(typeof(AboutPage1));
        }

        private void FavoritesListBoxItem1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            framek.Navigate(typeof(AboutPage2));
        }

        private void FavoritesListBoxItem2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            framek.Navigate(typeof(AboutPage1));
        }

        private void FavoritesListBoxItem3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            framek.Navigate(typeof(AboutPage2));
            Window.Current.Activate();
        }

        private void ShareListBoxItem_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            framek.Navigate(typeof(AboutPage1));
            Window.Current.Activate();
        }

        private void ShareListBoxItem_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            framek.Navigate(typeof(AboutPage2));
            Window.Current.Activate();

        }

        private void StackPanel_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            framek.Navigate(typeof(AboutPage));
            Window.Current.Activate();


        }

        private async void StackPanel_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        {
            //http://stackoverflow.com/questions/33666575/isolated-storage-for-uwp
            //http://stackoverflow.com/questions/21202953/saving-a-richtext-document-to-the-temp-folder-in-a-windows-store-app
            //http://www.c-sharpcorner.com/UploadFile/6d1860/how-to-implement-local-storage-in-universal-windows-apps/
            var tempFolder = ApplicationData.Current.TemporaryFolder;
            var tempFileCreate = await tempFolder.CreateFileAsync("TempFileName.tmp", CreationCollisionOption.ReplaceExisting);
            var tempFileOpen = await tempFolder.GetFileAsync("TempFileName.tmp");

            
            var folder = ApplicationData.Current.LocalFolder;
            var newFolder = await folder.CreateFolderAsync("NewFolder", CreationCollisionOption.OpenIfExists);

            //save
            var textFile = await newFolder.CreateFileAsync("text.txt");
            await FileIO.WriteTextAsync(textFile, "Hello World!");

            //get data
            var files = await newFolder.GetFilesAsync();
            var desiredFile = files.FirstOrDefault(x => x.Name == "text.txt");

            var textContent = await FileIO.ReadTextAsync(desiredFile);
            //textB.Text = textContent;
        }
    }
}
