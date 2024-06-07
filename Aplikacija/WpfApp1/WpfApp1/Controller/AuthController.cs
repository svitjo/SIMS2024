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
            this.authService.Logout();
        }
        public bool IsBlocked(string username)
        {
            return this.authService.IsBlocked(username);
        }
    }
}