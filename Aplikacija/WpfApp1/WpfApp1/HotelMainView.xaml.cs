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

namespace ReservationSystem
{
    /// <summary>
    /// Interaction logic for HotelMainView.xaml
    /// </summary>
    public partial class HotelMainView : Page
    {
        private HotelController hotelController;
        private readonly HotelService hotelService;
        private readonly HotelRepository hotelRepository;

        public HotelMainView()
        {
            InitializeComponent();
            hotelRepository = new HotelRepository(@"..\..\..\Data\hotel.json");
            hotelService = new HotelService(hotelRepository);
            hotelController = new HotelController(hotelService);

            LoadHotelData();
        }

        private void LoadHotelData()
        {
            var hotels = hotelController.GetAll();
            HotelsDataGrid.ItemsSource = hotels;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchBox.Text.ToLower();
            var hotels = hotelController.GetAll();
            var filteredHotels = hotels.Where(h => h.Name.ToLower().Contains(query)).ToList();
            HotelsDataGrid.ItemsSource = filteredHotels;
        }

        private void SortByConstructionYear_Click(object sender, RoutedEventArgs e)
        {
            var hotels = hotelController.GetAll();
            var sortedHotels = hotels.OrderBy(h => h.ConstructionYear).ToList();
            HotelsDataGrid.ItemsSource = sortedHotels;
        }

        private void SortByStarRating_Click(object sender, RoutedEventArgs e)
        {
            var hotels = hotelController.GetAll();
            var sortedHotels = hotels.OrderByDescending(h => h.StarRating).ToList();
            HotelsDataGrid.ItemsSource = sortedHotels;
        }
    }
}
