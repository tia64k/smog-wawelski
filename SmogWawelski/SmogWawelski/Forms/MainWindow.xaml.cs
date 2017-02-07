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

namespace SmogWawelski
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Refresh
        private void Refresh(object sender, RoutedEventArgs e)
        {
            int smog;
            string text = textBlock1.Text.Replace("%","");

            smog = Int32.Parse(text);
            smog++;
            textBlock1.Text = smog.ToString() + "%";
            
        }

        //About Us
        private void AboutUs(object sender, RoutedEventArgs e)
        {
            Forms.AboutUs about = new Forms.AboutUs();
            about.Show();
        }

        //Settings
        private void Settings(object sender, RoutedEventArgs e)
        {
            Forms.Settings settings = new Forms.Settings();
            settings.Show();
        }

        //Notifications
        private void Notifications(object sender, RoutedEventArgs e)
        {
            Forms.Notifications notifications = new Forms.Notifications();
            notifications.Show();
        }
    }
}
