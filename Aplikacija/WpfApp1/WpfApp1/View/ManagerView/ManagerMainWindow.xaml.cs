using ReservationSystem.Controller;
using ReservationSystem.View.ManagerView;
using System.Windows;

namespace ReservationSystem
{
    public partial class ManagerMainWindow : Window
    {
        private readonly AuthController authController;

        public ManagerMainWindow()
        {
            InitializeComponent();
            authController = GlobalVariables.AuthController;
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
            authController.Logout();
            GlobalVariables.CurrentUserEmail = null;
            var window = new MainWindow();
            this.Hide();
            Application.Current.MainWindow = window;
            window.Show();
            this.Close();
        }
        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ManagerReservationMainWindow());
        }
    }
}