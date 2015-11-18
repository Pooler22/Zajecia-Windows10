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
    }
}
