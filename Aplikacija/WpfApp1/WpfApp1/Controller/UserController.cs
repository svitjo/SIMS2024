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
        public bool Create(String jmbg, String email, String password, String firstname, String lastname, String phone)
        {
            var user = new User
            {
                Jmbg = jmbg,
                Email = email,
                Password = password,
                Firstname = firstname,
                Lastname = lastname,
                Phone = phone
            };

            return this.userService.Save(user);
        }
        public User GetById(String jmbg)
        {
            return this.userService.GetById(jmbg);
        }
        public bool DeleteById(String jmbg)
        {
            // TODO: implement
            return false;
        }
        public User GetByEmail(String email)
        {
            return this.userService.GetByEmail(email);
        }
    }
}