using Losev326_ProizvodPrakt.Components.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для CharactersPage.xaml
    /// </summary>
    public partial class CharactersPage : Page
    {
        public CharactersPage()
        {
            InitializeComponent();
            LvCharacters.ItemsSource = App.DB.Character.ToList();
            CbTypeCharacter.ItemsSource = App.DB.TypeCharacter.ToList();
            CbMoveSpeed.ItemsSource = App.DB.MoveSpeed.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CharacterAddEditPage(new Character()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedCharacter = LvCharacters.SelectedItem as Character;
            if (selectedCharacter == null)
            {
                MessageBox.Show("Выберите персонажа");
                return;
            }
            NavigationService.Navigate(new CharacterAddEditPage(selectedCharacter));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedCharacter = LvCharacters.SelectedItem as Character;
            if (selectedCharacter == null)
            {
                MessageBox.Show("Выберите персонажа");
                return;
            }
            App.DB.Character.Remove(selectedCharacter);
            App.DB.SaveChanges();
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            
            IEnumerable<Character> filterService = App.DB.Character;
                if (CbTypeCharacter.SelectedIndex == 0)
                    filterService = filterService.Where(x => x.TypeCharacterId == 1).ToList();
                else if (CbTypeCharacter.SelectedIndex == 1)
                    filterService = filterService.Where(x => x.TypeCharacterId == 2).ToList();

            if (CbMoveSpeed.SelectedIndex == 0)
                filterService = filterService.Where(x => x.MoveSpeedId == 1).ToList();
            else if (CbMoveSpeed.SelectedIndex == 1)
                filterService = filterService.Where(x => x.MoveSpeedId == 2).ToList();
            else if (CbMoveSpeed.SelectedIndex == 2)
                filterService = filterService.Where(x => x.MoveSpeedId == 3).ToList();
            else if (CbMoveSpeed.SelectedIndex == 3)
                filterService = filterService.Where(x => x.MoveSpeedId == 4).ToList();
            else if (CbMoveSpeed.SelectedIndex == 4)
                filterService = filterService.Where(x => x.MoveSpeedId == 5).ToList();

            if (TbSearch.Text.Length > 0)
            {
                filterService = filterService.Where(x => x.Name.ToLower().StartsWith(TbSearch.Text.ToLower()));
            }
            LvCharacters.ItemsSource = filterService.ToList();

        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            var selectedCharacter = LvCharacters.SelectedItem as Character;
            if (selectedCharacter == null)
            {
                MessageBox.Show("Выберите персонажа");
                return;
            }
            NavigationService.Navigate(new CharacterViewPage(selectedCharacter));
        }

        private void CbTypeCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

    }
}
