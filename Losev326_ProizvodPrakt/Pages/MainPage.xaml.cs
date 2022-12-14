using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Losev326_ProizvodPrakt.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.LoggedUser.Role.Id == 1)
            {
                BtnUsers.Visibility = Visibility.Visible;
            }
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new UsersPage());
        }

        private void BtnPerks_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new PerksPage());
        }

        private void BtnCharacters_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new CharactersPage());
        }

        private void BtnPowers_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new PowerPage());
        }

        private void BtnMaps_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new MapsPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            App.LoggedUser = null;
            NavigationService.Navigate(new LoginPage());
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new ProfilePage());
        }
    }
}
