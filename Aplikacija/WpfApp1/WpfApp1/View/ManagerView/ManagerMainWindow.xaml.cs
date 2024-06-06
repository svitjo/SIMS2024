using ReservationSystem.View.ManagerView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReservationSystem
{
    /// <summary>
    /// Interaction logic for ManagerMainWindow.xaml
    /// </summary>
    public partial class ManagerMainWindow : Window
    {
        public ManagerMainWindow()
        {
            InitializeComponent();
        }

        private void Hotels_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new HotelMainViewManager());
        }

        private void MyHotels_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new HotelMainViewByManager());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reservation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
