/***********************************************************************
 * Module:  GuestRepository.cs
 * Author:  User
 * Purpose: Definition of the Class Repository.GuestRepository
 ***********************************************************************/

using ReservationSystem.Model;
using ReservationSystem.Service;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Controller
{
   public class ReservationController
   {
        private ReservationService reservationService;

        public ReservationController(ReservationService reservationService)
        {
            this.reservationService = reservationService;
        }
        public List<Reservation> GetAll()
        {
            return this.reservationService.GetAll();
        }
      
        public Reservation GetById(String id)
        {
            return this.reservationService.GetById(id);
        }
        public bool DeleteById(String jmbg)
        {
            // TODO: implement
            return false;
        }
        public bool Create(String id, DateTime date, String apartmentID, ReservationStatus reservationStatus, String guestJMBG, String rejectionReason, String hotelID)
        {
            var reservation = new Reservation
            {
                Id = id,
                Date = date,
                ApartmentID = apartmentID,
                ReservationStatus = reservationStatus,
                GuestJMBG = guestJMBG,
                RejectionReason = rejectionReason,
                HotelID = hotelID
            };

            return this.reservationService.Save(reservation);
        }
        public bool ReservationExists(string apartmentId, DateTime date)
        {
            return this.reservationService.ReservationExists(apartmentId, date);
        }
    }
}