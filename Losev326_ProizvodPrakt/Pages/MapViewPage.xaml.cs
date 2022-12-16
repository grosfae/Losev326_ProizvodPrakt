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
    /// Логика взаимодействия для MapViewPage.xaml
    /// </summary>
    public partial class MapViewPage : Page
    {
        Map contextMap;
        public MapViewPage(Map map)
        {
            InitializeComponent();
            contextMap = map;
            DataContext = contextMap;
            LvPhotos.ItemsSource = App.DB.MapPhoto.Where(x => x.MapId == contextMap.Id).ToList();
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
