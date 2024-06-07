using System;

namespace ReservationSystem.Model
{
    public class User
    {
        public String Jmbg { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Phone { get; set; }
        public UserType UserType { get; set; }
        public bool IsBlocked { get; set; }
    }
}