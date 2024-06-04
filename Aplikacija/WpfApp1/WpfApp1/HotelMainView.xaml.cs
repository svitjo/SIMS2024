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
using System.Diagnostics;

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
        private ApartmentController apartmentController;
        private readonly ApartmentService apartmentService;
        private readonly ApartmentRepository apartmentRepository;

        public HotelMainView()
        {
            InitializeComponent();
            hotelRepository = new HotelRepository(@"..\..\..\Data\hotel.json");
            hotelService = new HotelService(hotelRepository);
            hotelController = new HotelController(hotelService);
            apartmentRepository = new ApartmentRepository(@"..\..\..\Data\apartment.json");
            apartmentService = new ApartmentService(apartmentRepository);
            apartmentController = new ApartmentController(apartmentService);
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
            List<Hotel> filteredHotels = new List<Hotel>();

            if (NameRadioButton.IsChecked == true)
            {
                filteredHotels = hotels.Where(h => h.Name.ToLower().Contains(query)).ToList();
            }
            else if (IdRadioButton.IsChecked == true)
            {
                filteredHotels = hotels.Where(h => h.Id.ToString().Contains(query)).ToList();
            }
            else if (YearRadioButton.IsChecked == true)
            {
                filteredHotels = hotels.Where(h => h.ConstructionYear.ToString().Contains(query)).ToList();
            }
            else if (RatingRadioButton.IsChecked == true)
            {
                filteredHotels = hotels.Where(h => h.StarRating.ToString().Contains(query)).ToList();
            }

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

        private void ToggleApartmentSearch_Click(object sender, RoutedEventArgs e)
        {
            ApartmentSearchPanel.Visibility = ApartmentSearchPanel.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SearchApartments_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(RoomsBox.Text, out int rooms);
            int.TryParse(GuestsBox.Text, out int guests);

            var hotels = hotelController.GetAll();
            var apartments = apartmentController.GetAll();
            Debug.WriteLine($"all Apartments Count: {apartments.Count}");

            List<Apartment> filteredApartments = new List<Apartment>();
            List<Hotel> filteredHotels = new List<Hotel>();

            if (RoomsRadioButton.IsChecked == true)
            {
                filteredApartments = apartments.Where(a => a.NumberOfRooms == rooms).ToList();
            }
            else if (GuestsRadioButton.IsChecked == true)
            {
                filteredApartments = apartments.Where(a => a.MaxGuests == guests).ToList();
            }
            else if (RoomsGuestsRadioButton.IsChecked == true)
            {
                filteredApartments = apartments.Where(a => a.NumberOfRooms == rooms || a.MaxGuests == guests).ToList();
            }

            Debug.WriteLine($"Filtered Apartments Count: {filteredApartments.Count}");

            var filteredHotelIds = filteredApartments.Select(a => a.HotelID).Distinct();

            Debug.WriteLine($"Filtered Hotel IDs Count: {filteredHotelIds.Count()}");

            filteredHotels = hotels.Where(h => filteredHotelIds.Contains(h.Id)).ToList();

            Debug.WriteLine($"Filtered Hotels Count: {filteredHotels.Count}");

            foreach (var hotel in filteredHotels)
            {
                hotel.Apartments = filteredApartments.Where(a => a.HotelID == hotel.Id).ToList();
                Debug.WriteLine($"Hotel: {hotel.Name}, Apartments Assigned: {hotel.Apartments.Count}");
            }

            HotelsDataGrid.ItemsSource = filteredHotels;
            Debug.WriteLine("DataGrid assignment complete.");
        }
    }
}