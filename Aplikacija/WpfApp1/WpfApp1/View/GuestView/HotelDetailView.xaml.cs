using ReservationSystem.Controller;
using ReservationSystem.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ReservationSystem
{
    public partial class HotelDetailView : Page
    {
        private HotelController hotelController;
        private ApartmentController apartmentController;
        private ReservationController reservationController;
        private UserController userController;
        private string currentHotelId;
        private bool _isDateSelected;

        public HotelDetailView(String id)
        {
            InitializeComponent();
            hotelController = GlobalVariables.HotelController;
            apartmentController = GlobalVariables.ApartmentController;
            reservationController = GlobalVariables.ReservationController;
            userController = GlobalVariables.UserController;
            currentHotelId = id;
            LoadHotelData(id);
        }
        private void LoadHotelData(String id)
        {
            var hotel = hotelController.GetById(id);
            if (hotel != null)
            {
                hotel.Apartments = apartmentController.GetAllByHotel(id);
                this.DataContext = hotel;
            }
            else
            {
                MessageBox.Show("Hotel not found");
            }
        }
        public bool IsDateSelected
        {
            get { return _isDateSelected; }
            set
            {
                _isDateSelected = value;
            }
        }
        private void SelectedDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            IsDateSelected = SelectedDatePicker.SelectedDate.HasValue;
        }
        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select a date first.");
                return;
            }

            var button = sender as Button;
            var apartment = button.Tag as Apartment;
            var selectedDate = SelectedDatePicker.SelectedDate.Value;
            var user = userController.GetByEmail(GlobalVariables.CurrentUserEmail);

            var isReserved = reservationController.ReservationExists(apartment.Name, selectedDate);

            if (isReserved)
            {
                MessageBox.Show("That apartment is reserved for that date, please choose another date or another apartment.");
            }
            else
            {
                reservationController.Create(selectedDate + apartment.Name, selectedDate, apartment.Name, ReservationStatus.OnWait, user.Jmbg, "", currentHotelId);
                MessageBox.Show("Reservation successful.");
            }
        }
    }
}