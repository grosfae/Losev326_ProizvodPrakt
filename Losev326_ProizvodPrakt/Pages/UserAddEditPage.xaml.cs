using Losev326_ProizvodPrakt.Components.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для UserAddEditPage.xaml
    /// </summary>
    public partial class UserAddEditPage : Page
    {
        User contextUser;
        public UserAddEditPage(User user)
        {
            InitializeComponent();
            CbRole.ItemsSource = App.DB.Role.ToList();
            contextUser = user;
            DataContext = contextUser;

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextUser.Nickname))
            {
                errorMessage += "Введите никнейм\n";
            }
            if (contextUser.Role == null)
            {
                errorMessage += "Выберите роль\n";
            }
            if (string.IsNullOrWhiteSpace(contextUser.Login))
            {
                errorMessage += "Введите логин\n";
            }
            if (string.IsNullOrWhiteSpace(contextUser.Password))
            {
                errorMessage += "Введите пароль\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextUser.Id == 0)
            {
                App.DB.User.Add(contextUser);
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
                contextUser.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextUser;
            }
        }
    }
}
