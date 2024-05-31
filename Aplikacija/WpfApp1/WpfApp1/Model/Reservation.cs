/***********************************************************************
 * Module:  Reservation.cs
 * Author:  User
 * Purpose: Definition of the Class Model.Reservation
 ***********************************************************************/

using System;

namespace ReservationSystem.Model
{
   public class Reservation
   {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String ApartmentID { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public String GuestJMBG { get; set; }
        public String RejectionReason { get; set; }
    }
}