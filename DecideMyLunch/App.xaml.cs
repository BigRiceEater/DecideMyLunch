using System;
using System.IO;
using System.Windows;

namespace DecideMyLunch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
   
    public partial class App : Application
    {

        public static string DatabaseLocation = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory , "decide-my-lunch.db");
    }
}
