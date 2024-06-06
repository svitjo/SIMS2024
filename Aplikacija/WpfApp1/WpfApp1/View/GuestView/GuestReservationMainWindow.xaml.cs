using ReservationSystem.Controller;
using ReservationSystem.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace ReservationSystem
{
    /// <summary>
    /// Interaction logic for GuestReservationMainWindow.xaml
    /// </summary>
    public partial class GuestReservationMainWindow : Page
    {
        private readonly ReservationController reservationController;
        private readonly ReservationService reservationService;
        private readonly ReservationRepository reservationRepository;
        private readonly UserController userController;
        private readonly UserService userService;
        private readonly UserRepository userRepository;
        private List<Reservation> allReservations;
        private ReservationStatus? selectedStatus;

        public GuestReservationMainWindow()
        {
            InitializeComponent();
            reservationRepository = new ReservationRepository(@"..\..\..\Data\reservation.json");
            reservationService = new ReservationService(reservationRepository);
            reservationController = new ReservationController(reservationService);
            userRepository = new UserRepository(@"..\..\..\Data\user.json");
            userService = new UserService(userRepository);
            userController = new UserController(userService);
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
