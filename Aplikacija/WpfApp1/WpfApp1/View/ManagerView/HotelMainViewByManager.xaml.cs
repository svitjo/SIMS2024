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

namespace ReservationSystem.View.ManagerView
{
    /// <summary>
    /// Interaction logic for HotelMainViewByManager.xaml
    /// </summary>
    public partial class HotelMainViewByManager : Page
    {
        private HotelController hotelController;
        private readonly HotelService hotelService;
        private readonly HotelRepository hotelRepository;
        private ApartmentController apartmentController;
        private readonly ApartmentService apartmentService;
        private readonly ApartmentRepository apartmentRepository;
        private readonly UserController userController;
        private readonly UserService userService;
        private readonly UserRepository userRepository;

        public HotelMainViewByManager()
        {
            InitializeComponent();
            hotelRepository = new HotelRepository(@"..\..\..\Data\hotel.json");
            hotelService = new HotelService(hotelRepository);
            hotelController = new HotelController(hotelService);
            apartmentRepository = new ApartmentRepository(@"..\..\..\Data\apartment.json");
            apartmentService = new ApartmentService(apartmentRepository);
            apartmentController = new ApartmentController(apartmentService);
            userRepository = new UserRepository(@"..\..\..\Data\user.json");
            userService = new UserService(userRepository);
            userController = new UserController(userService);

            LoadHotelData();
        }
        private void LoadHotelData()
        {
            var userEmail = GlobalVariables.CurrentUserEmail;
            var user = userController.GetByEmail(userEmail);
            var hotels = hotelController.GetAllByManager(user.Jmbg);
            HotelsDataGrid.ItemsSource = hotels;
        }
        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string hotelId = button.Tag.ToString();
                var hotel = hotelController.GetById(hotelId);

                HotelDetailViewManager detailView = new HotelDetailViewManager(hotelId);
                NavigationService.Navigate(detailView);
            }
        }
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string hotelId = button.Tag.ToString();
                NewApartmentWindow newApartmentWindow = new NewApartmentWindow(hotelId);
                bool? result = newApartmentWindow.ShowDialog();
                if (result == true)
                {
                    MessageBox.Show("Apartment added successfully.");
                }
            }
        }
    }
}
