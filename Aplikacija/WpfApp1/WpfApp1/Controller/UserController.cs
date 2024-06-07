using ReservationSystem.Model;
using ReservationSystem.Service;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Controller
{
    public class UserController
    {
        private UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }
        public List<User> GetAll()
        {
            return this.userService.GetAll();
        }
        public bool Create(String jmbg, String email, String password, String firstname, String lastname, String phone, UserType userType, bool isBlocked)
        {
            var user = new User
            {
                Jmbg = jmbg,
                Email = email,
                Password = password,
                Firstname = firstname,
                Lastname = lastname,
                Phone = phone,
                UserType = userType,
                IsBlocked = isBlocked
            };

            return this.userService.Save(user);
        }
        public User GetById(String jmbg)
        {
            return this.userService.GetById(jmbg);
        }
        public User GetByEmail(String email)
        {
            return this.userService.GetByEmail(email);
        }
        public void Block(string jmbg)
        {
            var user = userService.GetById(jmbg);
            if (user != null)
            {
                user.IsBlocked = user.IsBlocked ? false : true;
                userService.Block(user);
            }
            else
            {
                throw new Exception("User not found.");
            }
        }
    }
}