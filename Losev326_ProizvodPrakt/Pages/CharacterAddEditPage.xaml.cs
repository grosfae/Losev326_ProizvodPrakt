using Losev326_ProizvodPrakt.Components.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для CharacterAddEditPage.xaml
    /// </summary>
    public partial class CharacterAddEditPage : Page
    {
        Character contextCharacter;
        public CharacterAddEditPage(Character character)
        {
            InitializeComponent();
            CbMoveSpeed.ItemsSource = App.DB.MoveSpeed.ToList();
            CbTypeCharacter.ItemsSource = App.DB.TypeCharacter.ToList();
            contextCharacter = character;
            DataContext = contextCharacter;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextCharacter.Name))
            {
                errorMessage += "Введите ммя\n";
            }
            if (string.IsNullOrWhiteSpace(contextCharacter.History))
            {
                errorMessage += "Введите историю\n";
            }
            if (string.IsNullOrWhiteSpace(contextCharacter.Description))
            {
                errorMessage += "Введите описание\n";
            }
            if (contextCharacter.MoveSpeed == null)
            {
                errorMessage += "Выберите скорость передвижения\n";
            }
            if (contextCharacter.Power == null)
            {
                errorMessage += "Выберите способность\n";
            }
            if (contextCharacter.TerrorRadius == null)
            {
                errorMessage += "Выберите способность\n";
            }
            if (contextCharacter.TypeCharacter == null)
            {
                errorMessage += "Выберите роль персонажа\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextCharacter.Id == 0)
            {
                contextCharacter.TypeArticleId = 1;
                App.DB.Character.Add(contextCharacter);
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
                contextCharacter.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextCharacter;
            }
        }
    }
}
