using ReservationSystem.Controller;
using ReservationSystem.Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;

namespace ReservationSystem.View.ManagerView
{
    public partial class ManagerReservationMainWindow : Page
    {
        private HotelController hotelController;
        private ReservationController reservationController;
        private UserController userController;
        private List<Reservation> allReservations;
        public ManagerReservationMainWindow()
        {
            InitializeComponent();
            hotelController = GlobalVariables.HotelController;
            reservationController = GlobalVariables.ReservationController;
            userController = GlobalVariables.UserController;

            LoadReservationsForManager();
            StatusFilterComboBox.SelectedIndex = 0;
        }
        private void LoadReservationsForManager()
        {
            var userEmail = GlobalVariables.CurrentUserEmail;
            var user = userController.GetByEmail(userEmail);
            var hotels = hotelController.GetAllByManager(user.Jmbg);

            allReservations = new List<Reservation>();

            foreach (var hotel in hotels)
            {
                var reservations = reservationController.GetAllByHotel(hotel.Id);
                allReservations.AddRange(reservations);
            }

            ReservationsDataGrid.ItemsSource = allReservations;
        }
        private void StatusFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReservationsDataGrid != null)
            {
                var filteredReservations = new List<Reservation>();
                string selectedStatus = (StatusFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                if (selectedStatus == "All")
                {
                   filteredReservations = allReservations
                .Where(r => r.ReservationStatus == ReservationStatus.Approved || r.ReservationStatus == ReservationStatus.OnWait)
                .ToList();
                }
                else
                {
                    if (Enum.TryParse(selectedStatus.Replace(" ", ""), out ReservationStatus status))
                    {
                        filteredReservations = allReservations.Where(r => r.ReservationStatus == status).ToList();

                    }
                }
                ReservationsDataGrid.ItemsSource = filteredReservations;
            }
        }
    }
}