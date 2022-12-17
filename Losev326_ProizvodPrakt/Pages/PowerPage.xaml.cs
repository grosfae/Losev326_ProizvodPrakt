using Losev326_ProizvodPrakt.Components.Model;
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
    /// Логика взаимодействия для PowerPage.xaml
    /// </summary>
    public partial class PowerPage : Page
    {
        public PowerPage()
        {
            InitializeComponent();
            if (App.LoggedUser.Role.Id == 1 || App.LoggedUser.Role.Id == 2)
            {
                BtnAdd.Visibility = Visibility.Visible;
                BtnEdit.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
            }
            LvPowers.ItemsSource = App.DB.Power.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PowerAddEditPage(new Power()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedPower = LvPowers.SelectedItem as Power;
            if (selectedPower == null)
            {
                MessageBox.Show("Выберите способность");
                return;
            }
            NavigationService.Navigate(new PowerAddEditPage(selectedPower));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedPower = LvPowers.SelectedItem as Power;
            if (selectedPower == null)
            {
                MessageBox.Show("Выберите способность");
                return;
            }
            App.DB.Power.Remove(selectedPower);
            App.DB.SaveChanges();
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            if (string.IsNullOrWhiteSpace(TbSearch.Text))
            {
                LvPowers.ItemsSource = App.DB.Power.ToList();
            }
            else
            {
                LvPowers.ItemsSource = App.DB.Power.Where(a => a.Name.ToLower().Contains(TbSearch.Text.ToLower()) || a.Character.Name.ToLower().StartsWith(TbSearch.Text.ToLower())).ToList();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            var selectedPower = LvPowers.SelectedItem as Power;
            if (selectedPower == null)
            {
                MessageBox.Show("Выберите способность");
                return;
            }
            NavigationService.Navigate(new PowerViewPage(selectedPower));
        }
    }
}
