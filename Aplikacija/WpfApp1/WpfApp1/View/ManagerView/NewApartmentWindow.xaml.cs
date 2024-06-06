using ReservationSystem.Controller;
using ReservationSystem.Repository;
using ReservationSystem.Service;
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

namespace ReservationSystem.View.ManagerView
{
    /// <summary>
    /// Interaction logic for NewApartmentWindow.xaml
    /// </summary>
    public partial class NewApartmentWindow : Window
    {
        private string currentHotelId;
        private ApartmentController apartmentController;
        private readonly ApartmentService apartmentService;
        private readonly ApartmentRepository apartmentRepository;
        public NewApartmentWindow(String id)
        {
            InitializeComponent();
            apartmentRepository = new ApartmentRepository(@"..\..\..\Data\apartment.json");
            apartmentService = new ApartmentService(apartmentRepository);
            apartmentController = new ApartmentController(apartmentService);
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
