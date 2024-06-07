using ReservationSystem.Controller;
using ReservationSystem.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace ReservationSystem.View.AdminView
{
    public partial class UserMainWindow : Page
    {
        private UserController userController;

        public UserMainWindow()
        {
            InitializeComponent();
            userController = GlobalVariables.UserController;

            LoadUserData();
            UsersFilterComboBox.SelectedIndex = 0;
        }
        private void LoadUserData()
        {
            var users = userController.GetAll();
            UserDataGrid.ItemsSource = users;

        }
        private void UsersFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAndSortUsers();
        }
        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAndSortUsers();
        }
        private void FilterAndSortUsers()
        {
            if (UserDataGrid != null)
            {
                var users = userController.GetAll();
                var filteredUsers = new List<User>();
                string selectedStatus = (UsersFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                if (selectedStatus == "All")
                {
                    filteredUsers = users.Where(r => r.UserType == UserType.Guest || r.UserType == UserType.Manager).ToList();
                }
                else
                {
                    if (Enum.TryParse(selectedStatus.Replace(" ", ""), out UserType status))
                    {
                        filteredUsers = users.Where(r => r.UserType == status).ToList();
                    }
                }

                string selectedSortOption = (SortComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                if (!string.IsNullOrEmpty(selectedSortOption))
                {
                    switch (selectedSortOption)
                    {
                        case "Sort by First Name Asc":
                            filteredUsers = filteredUsers.OrderBy(u => u.Firstname).ToList();
                            break;
                        case "Sort by First Name Desc":
                            filteredUsers = filteredUsers.OrderByDescending(u => u.Firstname).ToList();
                            break;
                        case "Sort by Last Name Asc":
                            filteredUsers = filteredUsers.OrderBy(u => u.Lastname).ToList();
                            break;
                        case "Sort by Last Name Desc":
                            filteredUsers = filteredUsers.OrderByDescending(u => u.Lastname).ToList();
                            break;
                    }
                }

                UserDataGrid.ItemsSource = filteredUsers;
            }
        }
        private void BlockUnblockButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string userJmbg = button.Tag.ToString();
                var user = userController.GetById(userJmbg);
                userController.Block(user.Jmbg);
            }
            LoadUserData();
        }
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            var addUserWindow = new AddUserWindow(); 
            addUserWindow.ShowDialog();
            LoadUserData();
        }
    }
}