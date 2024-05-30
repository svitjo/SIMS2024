// File:    AuthService.cs
// Author:  Veljko
// Created: 02 May 2022 21:32:16
// Purpose: Definition of Class AuthService

using ReservationSystem.Model;
using ReservationSystem.Repository;
using System;

namespace ReservationSystem.Service
{
   public class AuthService
   {
        public UserRepository userRepository;

        public AuthService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public bool Login(string email, string password, out UserType userType)
        {
            userType = default;
            var user = userRepository.GetAll().Find(x => x.Email == email && x.Password == password);
            if (user == null)
            {
                return false;
            }
            userType = user.UserType;
            return true;
        }
      
        public void Logout()
        {
    
        }
   }
}