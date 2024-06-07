using ReservationSystem.Controller;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Linq;
using ReservationSystem.Model;

namespace ReservationSystem.View.ManagerView
{
    public partial class HotelMainViewByManager : Page
    {
        private HotelController hotelController;
        private readonly UserController userController;

        public HotelMainViewByManager()
        {
            InitializeComponent();
            hotelController = GlobalVariables.HotelController;
            userController = GlobalVariables.UserController;

            LoadHotelData();
        }
        private void LoadHotelData()
        {
            var userEmail = GlobalVariables.CurrentUserEmail;
            var user = userController.GetByEmail(userEmail);
            var hotels = hotelController.GetAllByManager(user.Jmbg);
            var acceptedHotels = hotels.Where(hotel => hotel.HotelStatus == HotelStatus.Accepted).ToList();
            var onWaitHotels = hotels.Where(hotel => hotel.HotelStatus == HotelStatus.OnWait).ToList();
            HotelsDataGrid.ItemsSource = acceptedHotels;
            OtherStatusHotelsDataGrid.ItemsSource = onWaitHotels;
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
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Hotel hotel)
            {
                hotelController.AcceptHotel(hotel.Id);
                LoadHotelData();
                MessageBox.Show("Hotel approved.");
            }
        }
        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Hotel hotel)
            {
                hotelController.RejectHotel(hotel.Id);
                LoadHotelData();
                MessageBox.Show("Hotel rejected.");
            }
        }
    }
}