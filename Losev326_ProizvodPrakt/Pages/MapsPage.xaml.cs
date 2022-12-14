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
    /// Логика взаимодействия для MapsPage.xaml
    /// </summary>
    public partial class MapsPage : Page
    {
        public MapsPage()
        {
            InitializeComponent();
            if (App.LoggedUser.Role.Id == 1 || App.LoggedUser.Role.Id == 2)
            {
                BtnAdd.Visibility = Visibility.Visible;
                BtnEdit.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
                BtnRestore.Visibility = Visibility.Visible;
            }
            LvMaps.ItemsSource = App.DB.Map.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MapAddEditPage(new Map()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedMap = LvMaps.SelectedItem as Map;
            if (selectedMap == null)
            {
                MessageBox.Show("Выберите локацию");
                return;
            }
            NavigationService.Navigate(new MapAddEditPage(selectedMap));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedMap = LvMaps.SelectedItem as Map;
            if (selectedMap == null)
            {
                MessageBox.Show("Выберите локацию");
                return;
            }
            selectedMap.IsDelete = true;
            App.DB.SaveChanges();
            Refresh();
        }
        private void BtnRestore_Click(object sender, RoutedEventArgs e)
        {
            var selectedMap = LvMaps.SelectedItem as Map;
            if (selectedMap == null)
            {
                MessageBox.Show("Выберите локацию");
                return;
            }
            selectedMap.IsDelete = false;
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
                LvMaps.ItemsSource = App.DB.Map.ToList();
            }
            else
            {
                LvMaps.ItemsSource = App.DB.Map.Where(a => a.Name.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            var selectedMap = LvMaps.SelectedItem as Map;
            if (selectedMap == null)
            {
                MessageBox.Show("Выберите локацию");
                return;
            }
            if (selectedMap.IsDelete == true)
            {
                MessageBox.Show("Статья больше неактуальна");
                return;
            }
            NavigationService.Navigate(new MapViewPage(selectedMap));
        }

    }
}
