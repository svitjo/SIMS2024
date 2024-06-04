using ReservationSystem.Model;
using ReservationSystem.Repository;
using System;

namespace ReservationSystem.Service
{
   public class AuthService
   {
        public UserRepository userRepository;
        private User currentUser;

        public AuthService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.currentUser = null;
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
            currentUser = user;
            return true;
        }
        public void Logout()
        {
            currentUser = null;
        }
    }
}