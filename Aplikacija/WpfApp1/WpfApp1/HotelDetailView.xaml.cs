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

namespace ReservationSystem
{
    public partial class HotelDetailView : Page
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

        public HotelDetailView(String id)
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
                hotel.Apartments = apartmentController.GetAllByHotel(id);
                this.DataContext = hotel;
            }
            else
            {
                MessageBox.Show("Hotel not found");
            }
        }
        private bool _isDateSelected;
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
                reservationController.Create("1", selectedDate, apartment.Name, ReservationStatus.OnWait, user.Jmbg, "", currentHotelId);
                MessageBox.Show("Reservation successful.");
            }
        }
    }
}
