using ReservationSystem.Controller;
using ReservationSystem.View.AdminView;
using System.Windows;

namespace ReservationSystem
{
    public partial class AdminMainWindow : Window
    {
        private readonly AuthController authController;

        public AdminMainWindow()
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
            MainContent.Navigate(new HotelMainViewAdmin());
        }
        private void Users_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new UserMainWindow());
        }
    }
}