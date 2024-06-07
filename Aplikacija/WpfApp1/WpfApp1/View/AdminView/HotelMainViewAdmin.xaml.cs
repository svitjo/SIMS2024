using ReservationSystem.Controller;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using ReservationSystem.Model;

namespace ReservationSystem.View.AdminView
{
    public partial class HotelMainViewAdmin : Page
    {
        private HotelController hotelController;
        private ApartmentController apartmentController;

        public HotelMainViewAdmin()
        {
            InitializeComponent();
            hotelController = GlobalVariables.HotelController;
            apartmentController = GlobalVariables.ApartmentController;
            LoadHotelData();
        }
        private void LoadHotelData()
        {
            var hotels = hotelController.GetAll();
            var acceptedHotels = hotels.Where(hotel => hotel.HotelStatus == HotelStatus.Accepted).ToList();
            HotelsDataGrid.ItemsSource = acceptedHotels;
        }
        private void AddHotel_Click(object sender, RoutedEventArgs e)
        {
            AddHotelWindow addHotelWindow = new AddHotelWindow();
            addHotelWindow.ShowDialog();
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

            var filteredHotelIds = filteredApartments.Select(a => a.HotelID).Distinct();
            filteredHotels = hotels.Where(h => filteredHotelIds.Contains(h.Id)).ToList();

            foreach (var hotel in filteredHotels)
            {
                hotel.Apartments = filteredApartments.Where(a => a.HotelID == hotel.Id).ToList();
            }

            HotelsDataGrid.ItemsSource = filteredHotels;
        }
    }
}