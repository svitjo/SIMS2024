using ReservationSystem.Controller;
using ReservationSystem.Model;
using System;
using System.Windows;

namespace ReservationSystem
{
    public partial class MainWindow : Window
    {
        private AuthController authController;
        private int failedLoginAttempts = 0;
        public MainWindow()
        {
            InitializeComponent();
            authController = GlobalVariables.AuthController;
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = Username_TB.Text;
            if (authController.IsBlocked(username))
            {
                MessageBox.Show("Your account is blocked. Please contact support.", "Blocked Account", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (authController.Login(Username_TB.Text, Password_TB.Text, out UserType userType))
            {
                GlobalVariables.CurrentUserEmail = Username_TB.Text;
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