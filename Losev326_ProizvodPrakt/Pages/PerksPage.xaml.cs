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
    /// Логика взаимодействия для PerksPage.xaml
    /// </summary>
    public partial class PerksPage : Page
    {
        public PerksPage()
        {
            InitializeComponent();
            if (App.LoggedUser.Role.Id == 1 || App.LoggedUser.Role.Id == 2)
            {
                BtnAdd.Visibility = Visibility.Visible;
                BtnEdit.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
                BtnRestore.Visibility = Visibility.Visible;
            }
            LvPerks.ItemsSource = App.DB.Perk.ToList();
            CbTypePerk.ItemsSource = App.DB.TypeCharacter.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PerkAddEditPage(new Perk()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedPerk = LvPerks.SelectedItem as Perk;
            if (selectedPerk == null)
            {
                MessageBox.Show("Выберите навык");
                return;
            }
            NavigationService.Navigate(new PerkAddEditPage(selectedPerk));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedPerk = LvPerks.SelectedItem as Perk;
            if (selectedPerk == null)
            {
                MessageBox.Show("Выберите навык");
                return;
            }
            selectedPerk.IsDelete = true;
            App.DB.SaveChanges();
            Refresh();
        }
        private void BtnRestore_Click(object sender, RoutedEventArgs e)
        {
            var selectedPerk = LvPerks.SelectedItem as Perk;
            if (selectedPerk == null)
            {
                MessageBox.Show("Выберите навык");
                return;
            }
            selectedPerk.IsDelete = false;
            App.DB.SaveChanges();
            Refresh();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {

            IEnumerable<Perk> filterService = App.DB.Perk;
            if (CbTypePerk.SelectedIndex == 0)
                filterService = filterService.Where(x => x.TypePerkId == 1).ToList();
            else if (CbTypePerk.SelectedIndex == 1)
                filterService = filterService.Where(x => x.TypePerkId == 2).ToList();

            if (TbSearch.Text.Length > 0)
            {
                filterService = filterService.Where(x => x.Name.ToLower().StartsWith(TbSearch.Text.ToLower()) || x.Character.Name.ToLower().StartsWith(TbSearch.Text.ToLower()));
            }
            LvPerks.ItemsSource = filterService.ToList();

        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            var selectedPerk = LvPerks.SelectedItem as Perk;
            if (selectedPerk == null)
            {
                MessageBox.Show("Выберите навык");
                return;
            }
            if (selectedPerk.IsDelete == true)
            {
                MessageBox.Show("Статья больше неактуальна");
                return;
            }
            NavigationService.Navigate(new PerkViewPage(selectedPerk));
        }

        private void CbTypeCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

    }
}
