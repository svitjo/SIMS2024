using ReservationSystem.Controller;
using System;
using System.Windows;

namespace ReservationSystem.View.ManagerView
{
    public partial class NewApartmentWindow : Window
    {
        private string currentHotelId;
        private ApartmentController apartmentController;

        public NewApartmentWindow(String id)
        {
            InitializeComponent();
            apartmentController = GlobalVariables.ApartmentController;
            currentHotelId = id;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string description = DescriptionTextBox.Text;
            int numberOfRooms = int.Parse(NumberOfRoomsTextBox.Text);
            int maxGuests = int.Parse(MaxGuestsTextBox.Text);

            bool success = apartmentController.Create(name, description, numberOfRooms, maxGuests, currentHotelId);
            if (success)
            {
                MessageBox.Show("Apartment created successfully!");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to create apartment.");
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}