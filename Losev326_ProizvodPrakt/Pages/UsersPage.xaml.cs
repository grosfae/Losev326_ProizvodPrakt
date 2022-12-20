using Losev326_ProizvodPrakt.Components.Model;
using Losev326_ProizvodPrakt.Pages;
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

namespace Losev326_ProizvodPrakt
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            LvUsers.ItemsSource = App.DB.User.Where(x => x.Id != App.LoggedUser.Id).ToList();
            CbRole.ItemsSource = App.DB.Role.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserAddEditPage(new User()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = LvUsers.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }
            NavigationService.Navigate(new UserAddEditPage(selectedUser));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = LvUsers.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Выберите персонажа");
                return;
            }
            App.DB.User.Remove(selectedUser);
            App.DB.SaveChanges();
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {

            IEnumerable<User> filterService = App.DB.User;
            if (CbRole.SelectedIndex == 0)
                filterService = filterService.Where(x => x.RoleId == 1).ToList();
            else if (CbRole.SelectedIndex == 1)
                filterService = filterService.Where(x => x.RoleId == 2).ToList();
            else if (CbRole.SelectedIndex == 2)
                filterService = filterService.Where(x => x.RoleId == 3).ToList();
            if (TbSearch.Text.Length > 0)
            {
                filterService = filterService.Where(x => x.Nickname.ToLower().StartsWith(TbSearch.Text.ToLower()));
            }
            LvUsers.ItemsSource = filterService.Where(x => x.Id != App.LoggedUser.Id).ToList();

        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
