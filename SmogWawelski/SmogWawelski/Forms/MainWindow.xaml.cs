using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        Timer aTimer;
        private static int lastHour, smogNorms;
        private static bool isNotification;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            aTimer = new Timer(60000); 
            lastHour = DateTime.Now.Hour;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.AutoReset = true;
            aTimer.Start();
        }

        //Refresh
        private void Refresh(object sender, RoutedEventArgs e)
        {
            string text = textBlock1.Text.Replace("%","");

            smogNorms = Int32.Parse(text);
            textBlock1.Text = smogNorms.ToString() + "%";
            
        }

        //About Us
        private void AboutUs(object sender, RoutedEventArgs e)
        {
            Forms.AboutUs about = new Forms.AboutUs();
            about.Owner = this;
            about.Show();
        }

        //Settings
        private void Settings(object sender, RoutedEventArgs e)
        {
            Forms.Settings settings = new Forms.Settings();
            settings.Owner = this;
            settings.Show();
        }

        //Notifications
        private void Notifications_checked(object sender, RoutedEventArgs e)
        {
            isNotification = true;
            Forms.NotificationWindow notification = new Forms.NotificationWindow(smogNorms);
            notification.Show();
        }
        private void Notifications_unchecked(object sender, RoutedEventArgs e)
        {
            isNotification = false;
        }

        
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if ((lastHour < DateTime.Now.Hour || (lastHour == 23 && DateTime.Now.Hour == 0)) && isNotification == true)
            {
                lastHour = DateTime.Now.Hour;
                Forms.NotificationWindow notification = new Forms.NotificationWindow(smogNorms);
                notification.Show();
            }

        }
    }
}
