using ReservationSystem.Controller;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using ReservationSystem.Model;

namespace ReservationSystem
{
    public partial class GuestReservationMainWindow : Page
    {
        private readonly ReservationController reservationController;
        private readonly UserController userController;
        private List<Reservation> allReservations;
        private ReservationStatus? selectedStatus;

        public GuestReservationMainWindow()
        {
            InitializeComponent();
            reservationController = GlobalVariables.ReservationController;
            userController = GlobalVariables.UserController;
            LoadReservations();
        }
        private void LoadReservations()
        {
            var userEmail = GlobalVariables.CurrentUserEmail;
            var user = userController.GetByEmail(userEmail);
            allReservations = reservationController.GetAllByGuest(user.Jmbg);
            FilterReservations();
        }
        private void FilterReservations()
        {
            if (allReservations == null) return;

            var filteredReservations = selectedStatus == null
                ? allReservations
                : allReservations.Where(r => r.ReservationStatus == selectedStatus).ToList();

            ReservationsDataGrid.ItemsSource = filteredReservations;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var selectedRadioButton = sender as RadioButton;
            selectedStatus = selectedRadioButton?.Tag switch
            {
                ReservationStatus.OnWait => ReservationStatus.OnWait,
                ReservationStatus.Approved => ReservationStatus.Approved,
                ReservationStatus.Rejected => ReservationStatus.Rejected,
                _ => null,
            };
            FilterReservations();
        }
        private void CancelReservation_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var reservation = button.DataContext as Reservation;

            if (reservation.ReservationStatus == ReservationStatus.Approved || reservation.ReservationStatus == ReservationStatus.OnWait)
            {
                if (reservationController.CancelReservation(reservation.Id))
                {
                    MessageBox.Show("Reservation cancelled successfully.");
                    LoadReservations();
                }
                else
                {
                    MessageBox.Show("Failed to cancel the reservation.");
                }
            }
            else
            {
                MessageBox.Show("Cannot cancel this reservation.");
            }
        }
    }
}