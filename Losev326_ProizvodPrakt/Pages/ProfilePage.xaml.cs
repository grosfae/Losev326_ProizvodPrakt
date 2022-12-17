using Losev326_ProizvodPrakt.Components.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            TbNickname.Text = App.LoggedUser.Nickname;
            TbLogin.Text = App.LoggedUser.Login;
            TbPassword.Text = App.LoggedUser.Password;

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(App.LoggedUser.Nickname))
            {
                errorMessage += "Введите никнейм\n";
            }
            if (string.IsNullOrWhiteSpace(App.LoggedUser.Password))
            {
                errorMessage += "Введите пароль\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (App.LoggedUser.Id == 0)
            {
                App.DB.User.Add(App.LoggedUser);
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();

        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnEditImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                App.LoggedUser.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = App.LoggedUser;
            }
        }
    }
}
