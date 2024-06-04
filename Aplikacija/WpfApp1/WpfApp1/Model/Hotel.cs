using System;
using System.Collections.Generic;

namespace ReservationSystem.Model
{
   public class Hotel
   {
        public String Id { get; set; }
        public String Name { get; set; }
        public double ConstructionYear { get; set; }
        public int StarRating { get; set; }
        public String OwnerJMBG { get; set; }
        public List<Apartment> Apartments { get; set; }
    }
}