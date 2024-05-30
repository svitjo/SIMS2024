// File:    AuthController.cs
// Author:  Veljko
// Created: 02 May 2022 22:17:47
// Purpose: Definition of Class AuthController

using ReservationSystem.Service;
using ReservationSystem.Model;
using System;

namespace ReservationSystem.Controller
{
   public class AuthController
   {
        private AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }
        public bool Login(string username, string password, out UserType userType)
        {
            return this.authService.Login(username, password, out userType);
        }
      
        public void Logout()
        {
        // TODO: implement
        }
   
   
        }
}