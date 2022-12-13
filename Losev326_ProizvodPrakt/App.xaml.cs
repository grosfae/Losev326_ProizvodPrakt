using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Losev326_ProizvodPrakt.Components.Model;

namespace Losev326_ProizvodPrakt
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DbdWikiEntities DB = new DbdWikiEntities();
        public static User LoggedUser;
    }
}   
