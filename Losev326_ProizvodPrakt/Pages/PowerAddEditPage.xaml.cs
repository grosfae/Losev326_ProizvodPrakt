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
    /// Логика взаимодействия для PowerAddEditPage.xaml
    /// </summary>
    public partial class PowerAddEditPage : Page
    {
        Power contextPower;
        public PowerAddEditPage(Power power)
        {
            InitializeComponent();
            CbCharacter.ItemsSource = App.DB.Character.Where(x => x.TypeCharacterId == 1).ToList();
            CbTypePower.ItemsSource = App.DB.TypePower.ToList();
            contextPower = power;
            DataContext = contextPower;

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextPower.Name))
            {
                errorMessage += "Введите название\n";
            }
            if (string.IsNullOrWhiteSpace(contextPower.Description))
            {
                errorMessage += "Введите описание\n";
            }
            if (contextPower.TypePower == null)
            {
                errorMessage += "Выберите тип способности\n";
            }
            if (string.IsNullOrWhiteSpace(contextPower.Count))
            {
                errorMessage += "Введите количество зарядов\n";
            }
            if (string.IsNullOrWhiteSpace(contextPower.Range))
            {
                errorMessage += "Введите радиус\n";
            }
            if (contextPower.Character == null)
            {
                errorMessage += "Выберите обладателя\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextPower.Id == 0)
            {
                contextPower.TypeArticleId = 2;
                App.DB.Power.Add(contextPower);
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
                contextPower.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextPower;
            }
        }
    }
}
