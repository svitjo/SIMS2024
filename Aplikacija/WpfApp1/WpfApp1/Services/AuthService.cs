using ReservationSystem.Model;
using ReservationSystem.Repository;

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
        public bool IsBlocked(string username)
        {
            var user = userRepository.GetByEmail(username);
            return user != null && user.IsBlocked;
        }
    }
}