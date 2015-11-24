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

namespace Week3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        StorageFolder newFolder;

        public MainPage()
        {
            this.InitializeComponent();
            openFolder();
        }

        private void butonik_Click1(object sender, RoutedEventArgs e)
        {
            openFolder();
        }

        private void butonik_Click2(object sender, RoutedEventArgs e)
        {
            //saveFile();
        }

        private void butonik_Click3(object sender, RoutedEventArgs e)
        {
            readeFile();
        }

        async void openFolder()
        {
            var folder = ApplicationData.Current.LocalFolder;
            newFolder = await folder.CreateFolderAsync("NewFolder", CreationCollisionOption.OpenIfExists);
            test1.Text = "Done";

        }

        async void saveFile(string textIn)
        {
            try
            {
                StorageFile file = await newFolder.GetFileAsync("text3asd.txt");
                await FileIO.WriteTextAsync(file, textIn);
            }
            catch(FileNotFoundException){
                var textFile = await newFolder.CreateFileAsync("text3asd.txt");
                await FileIO.WriteTextAsync(textFile, textIn);
            }
        }

        async void readeFile()
        {
            var files = await newFolder.GetFilesAsync();
            var desiredFile = files.FirstOrDefault(x => x.Name == "text3asd.txt");
            var textContent = await FileIO.ReadTextAsync(desiredFile);
            test3.Text = textContent;

        }

        private void Ellipse_PointerPressed1(object sender, PointerRoutedEventArgs e)
        {
            saveFile("Green");
        }
        private void Ellipse_PointerPressed2(object sender, PointerRoutedEventArgs e)
        {
            saveFile("Yelolow");
        }
        private void Ellipse_PointerPressed3(object sender, PointerRoutedEventArgs e)
        {
            saveFile("Red");
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            //base.OnNavigatedTo(e);
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            test1.Text = "welcome phone";
        }
    }
}
