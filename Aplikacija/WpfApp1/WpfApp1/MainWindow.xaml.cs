using ReservationSystem.Controller;
using ReservationSystem.Model;
using ReservationSystem.Repository;
using ReservationSystem.Service;
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

namespace ReservationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AuthController authController;
        private readonly AuthService authService;
        private readonly UserRepository userRepository;

        private int failedLoginAttempts = 0;

        public MainWindow()
        {
            InitializeComponent();
            userRepository = new UserRepository(@"..\..\..\Data\user.json");
            authService = new AuthService(userRepository);
            authController = new AuthController(authService);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (authController.Login(Username_TB.Text, Password_TB.Text, out UserType userType))
            {
                failedLoginAttempts = 0;
                OnLoginRedirect(userType);
            }
            else
            {
                try
                {
                    failedLoginAttempts++;
                    Console.WriteLine("Not valid.");
                    if (failedLoginAttempts >= 3)
                    {
                        Console.WriteLine("Maximum login attempts exceeded. Shutting down the application.");
                        Application.Current.Shutdown();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                }
            }
        }

        private void OnLoginRedirect(UserType userType)
        {
            Window window;
            if (userType == UserType.Administrator)
            {
                window = new AdminMainWindow();
            }
            else if (userType == UserType.Manager)
            {
                window = new ManagerMainWindow();
            }
            else if (userType == UserType.Guest)
            {
                window = new GuestMainWindow();
            }
            else
            {
                return;
            }
            Application.Current.MainWindow = window;
            this.Close();
            window.Show();
        }
    }
}
