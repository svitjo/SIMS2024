using ReservationSystem.Controller;
using ReservationSystem.Model;
using System.Windows;
using System.Windows.Controls;

namespace ReservationSystem.View.AdminView
{
    public partial class AddUserWindow : Window
    {
        private UserController userController;

        public AddUserWindow()
        {
            InitializeComponent();
            userController = GlobalVariables.UserController;
        }
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var jmbg = JmbgTextBox.Text;

            var existingUserByEmail = userController.GetByEmail(email);
            var existingUserById = userController.GetById(jmbg);

            if (existingUserByEmail != null)
            {
                MessageBox.Show("A user with this email already exists.");
                return;
            }

            if (existingUserById != null)
            {
                MessageBox.Show("A user with this JMBG already exists.");
                return;
            }
            userController.Create(JmbgTextBox.Text, EmailTextBox.Text, PasswordBox.Password, FirstnameTextBox.Text, LastnameTextBox.Text, PhoneTextBox.Text, UserType.Manager, false);
            MessageBox.Show("User added.");
            this.Close();
        }
    }
}