using ReservationSystem.Controller;
using System.Windows;


namespace ReservationSystem
{
    public partial class GuestMainWindow : Window
    {
        private AuthController authController;

        public GuestMainWindow()
        {
            InitializeComponent();
            authController = GlobalVariables.AuthController;
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
        private void Hotels_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new HotelMainView());
        }
        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new GuestReservationMainWindow());
        }
    }
}