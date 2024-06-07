using ReservationSystem.Controller;
using ReservationSystem.Repository;
using ReservationSystem.Service;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using ReservationSystem.Model;
using ReservationSystem.View.ManagerView;

namespace ReservationSystem
{
    public partial class HotelDetailViewManager : Page
    {
        private HotelController hotelController;
        private readonly ReservationController reservationController;
        private string currentHotelId;

        public HotelDetailViewManager(String id)
        {
            InitializeComponent();
            hotelController = GlobalVariables.HotelController;
            reservationController = GlobalVariables.ReservationController;
            currentHotelId = id;
            LoadHotelData(id);
        }
        private void LoadHotelData(String id)
        {
            var hotel = hotelController.GetById(id);
            if (hotel != null)
            {
                this.DataContext = hotel;
                var reservations = reservationController.GetAllByHotel(id);
                if (reservations != null && reservations.Any())
                {
                    System.Diagnostics.Debug.WriteLine($"Loaded {reservations.Count} reservations for hotel {id}.");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"No reservations found for hotel {id}.");
                }
                ReservationsDataGrid.ItemsSource = reservations;
            }
            else
            {
                MessageBox.Show("Hotel not found");
            }
        }
        private void ApproveReservation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Reservation reservation)
            {
                reservationController.ApproveReservation(reservation.Id);
                LoadHotelData(currentHotelId);
                MessageBox.Show("Reservation approved.");
            }
        }
        private void RejectReservation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Reservation reservation)
            {
                var rejectDialog = new RejectReason();
                if (rejectDialog.ShowDialog() == true)
                {
                    string reason = rejectDialog.Reason; ;
                    try
                    {
                        reservationController.RejectReservation(reservation.Id, reason);
                        LoadHotelData(currentHotelId); 
                        MessageBox.Show("Reservation rejected.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error rejecting reservation: {ex.Message}");
                    }
                }
            }
        }
    }
}