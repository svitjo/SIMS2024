using ReservationSystem.Controller;
using ReservationSystem.Model;
using System.Windows;

namespace ReservationSystem.View.AdminView
{
    public partial class AddHotelWindow : Window
    {
        private HotelController hotelController;

        public AddHotelWindow()
        {
            hotelController = GlobalVariables.HotelController;
            InitializeComponent();
        }
        private void AddHotel_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string ownerJMBG = OwnerJMBGTextBox.Text;
            int starRating = int.Parse(StarRatingTextBox.Text);
            int constructionYear = int.Parse(ConstructionYearTextBox.Text);

            bool success = hotelController.Create(name + constructionYear, name, constructionYear, starRating, ownerJMBG, HotelStatus.OnWait);
            if (success)
            {
                MessageBox.Show("Hotel created successfully!");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to create hotel.");
            }
        }
    }
}