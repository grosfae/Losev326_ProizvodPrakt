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
    /// Логика взаимодействия для CharacterViewPage.xaml
    /// </summary>
    public partial class CharacterViewPage : Page
    {
        Character contextCharacter;
        public CharacterViewPage(Character character)
        {
            InitializeComponent();
            contextCharacter = character;
            DataContext = contextCharacter;
            LvPerks.ItemsSource = App.DB.Perk.Where(x => x.CharacterId == contextCharacter.Id).ToList();
            LvPower.ItemsSource = App.DB.Power.Where(x => x.CharacterId == contextCharacter.Id).ToList();
            if (contextCharacter.TypeCharacterId == 2)
            {
                StPower.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
