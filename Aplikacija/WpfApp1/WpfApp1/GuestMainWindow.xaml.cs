using ReservationSystem.Controller;
using ReservationSystem.Repository;
using ReservationSystem.Service;
using System;
using System.Windows;


namespace ReservationSystem
{
    /// <summary>
    /// Interaction logic for GuestMainWindow.xaml
    /// </summary>
    public partial class GuestMainWindow : Window
    {
        private readonly AuthController authController;
        private readonly AuthService authService;
        private readonly UserRepository userRepository;
        public GuestMainWindow()
        {
            InitializeComponent();
            userRepository = new UserRepository(@"..\..\..\Data\user.json");
            authService = new AuthService(userRepository);
            authController = new AuthController(authService);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            authController.Logout();
            var window = new MainWindow();
            this.Hide();
            Application.Current.MainWindow = window;
            window.Show();
            this.Close();
        }

        private void Hotels_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Test.");
        }

        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Test.");
        }
    }
}