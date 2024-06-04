using System;

namespace ReservationSystem.Model
{
   public class Apartment
   {
        public String Name { get; set; }
        public String Description { get; set; }
        public int NumberOfRooms { get; set; }
        public int MaxGuests { get; set; }
        public String HotelID { get; set; }
    }
}