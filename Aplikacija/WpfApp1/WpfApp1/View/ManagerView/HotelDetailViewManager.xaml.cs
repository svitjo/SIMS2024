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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using ReservationSystem.Model;
using ReservationSystem.View.ManagerView;

namespace ReservationSystem
{
    /// <summary>
    /// Interaction logic for HotelDetailViewManager.xaml
    /// </summary>
    public partial class HotelDetailViewManager : Page
    {
        private HotelController hotelController;
        private readonly HotelService hotelService;
        private readonly HotelRepository hotelRepository;
        private ApartmentController apartmentController;
        private readonly ApartmentService apartmentService;
        private readonly ApartmentRepository apartmentRepository;
        private readonly ReservationController reservationController;
        private readonly ReservationService reservationService;
        private readonly ReservationRepository reservationRepository;
        private readonly UserController userController;
        private readonly UserService userService;
        private readonly UserRepository userRepository;
        private string currentHotelId;
        public HotelDetailViewManager(String id)
        {
            InitializeComponent();
            hotelRepository = new HotelRepository(@"..\..\..\Data\hotel.json");
            hotelService = new HotelService(hotelRepository);
            hotelController = new HotelController(hotelService);
            apartmentRepository = new ApartmentRepository(@"..\..\..\Data\apartment.json");
            apartmentService = new ApartmentService(apartmentRepository);
            apartmentController = new ApartmentController(apartmentService);
            reservationRepository = new ReservationRepository(@"..\..\..\Data\reservation.json");
            reservationService = new ReservationService(reservationRepository);
            reservationController = new ReservationController(reservationService);
            userRepository = new UserRepository(@"..\..\..\Data\user.json");
            userService = new UserService(userRepository);
            userController = new UserController(userService);
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
