using Losev326_ProizvodPrakt.Components.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для PerkAddEditPage.xaml
    /// </summary>
    public partial class PerkAddEditPage : Page
    {
        Perk contextPerk;
        public PerkAddEditPage(Perk perk)
        {
            InitializeComponent();
            CbCharacter.ItemsSource = App.DB.Character.ToList();
            CbTypePerk.ItemsSource = App.DB.TypePerk.ToList();
            contextPerk = perk;
            DataContext = contextPerk;

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextPerk.Name))
            {
                errorMessage += "Введите название\n";
            }
            if (string.IsNullOrWhiteSpace(contextPerk.Description))
            {
                errorMessage += "Введите описание\n";
            }
            if (contextPerk.TypePerk == null)
            {
                errorMessage += "Выберите тип навыка\n";
            }
            if (contextPerk.Character == null)
            {
                errorMessage += "Выберите обладателя\n";
            }
            if (contextPerk.Image == null)
            {
                errorMessage += "Добавьте картинку\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextPerk.Id == 0)
            {
                contextPerk.TypeArticleId = 3;
                App.DB.Perk.Add(contextPerk);
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
                contextPerk.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextPerk;
            }
        }

        private void CbTypePerk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CbTypePerk.SelectedIndex == 0)
            {
                CbCharacter.ItemsSource = App.DB.Character.Where(x => x.TypeCharacterId == 1).ToList();
            }
            else if (CbTypePerk.SelectedIndex == 1)
            {
                CbCharacter.ItemsSource = App.DB.Character.Where(x => x.TypeCharacterId == 2).ToList();
            }
        }
    }
}
