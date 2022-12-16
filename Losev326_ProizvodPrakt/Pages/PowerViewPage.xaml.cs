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
    /// Логика взаимодействия для PowerViewPage.xaml
    /// </summary>
    public partial class PowerViewPage : Page
    {
        Power contextPower;
        public PowerViewPage(Power power)
        {
            InitializeComponent();
            contextPower = power;
            DataContext = contextPower;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
