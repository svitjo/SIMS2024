using System;

namespace ReservationSystem.Model
{
    public class Reservation
    {
        public String Id { get; set; }
        public DateTime Date { get; set; }
        public String ApartmentID { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public String GuestJMBG { get; set; }
        public String RejectionReason { get; set; }
        public String HotelID { get; set; }
    }
}