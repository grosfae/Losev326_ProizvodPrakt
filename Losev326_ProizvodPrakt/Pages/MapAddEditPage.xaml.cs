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
    /// Логика взаимодействия для MapAddEditPage.xaml
    /// </summary>
    public partial class MapAddEditPage : Page
    {
        Map contextMap;
        public MapAddEditPage(Map map)
        {
            InitializeComponent();
            contextMap = map;
            DataContext = contextMap;
            LvPhotos.ItemsSource = App.DB.MapPhoto.Where(x => x.MapId == contextMap.Id).ToList();

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextMap.Name))
            {
                errorMessage += "Введите название\n";
            }
            if (string.IsNullOrWhiteSpace(contextMap.History))
            {
                errorMessage += "Введите историю\n";
            }
            if (string.IsNullOrWhiteSpace(contextMap.Specials))
            {
                errorMessage += "Введите особенности\n";
            }
            if (contextMap.Image == null)
            {
                errorMessage += "Добавьте картинку\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextMap.Id == 0)
            {
                contextMap.TypeArticleId = 4;
                App.DB.Map.Add(contextMap);
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
                contextMap.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextMap;
            }
        }
        private void AddIngBtn_Click(object sender, RoutedEventArgs e)
        {
            MapPhoto mapPhoto = new MapPhoto();
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextMap = App.DB.Map.ToList().Find(x => x.Id == contextMap.Id);
                if (contextMap == null)
                {
                    MessageBox.Show("Перед добавлением галереи нужно создать карту");
                    return;
                }
                mapPhoto.ImagePath = File.ReadAllBytes(dialog.FileName);
                mapPhoto.MapId = contextMap.Id;
                App.DB.MapPhoto.Add(mapPhoto);
                App.DB.SaveChanges();
                LvPhotos.ItemsSource = App.DB.MapPhoto.Where(x => x.MapId == contextMap.Id).ToList();
            }
        }

        private void DeleteIngBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedPhoto = LvPhotos.SelectedItem as MapPhoto;
            if (selectedPhoto == null)
            {
                MessageBox.Show("Выберите картинку из галереи");
                return;
            }
            App.DB.MapPhoto.Remove(selectedPhoto);
            App.DB.SaveChanges();
            LvPhotos.ItemsSource = App.DB.MapPhoto.Where(x => x.MapId == contextMap.Id).ToList();
        }
    }
}
