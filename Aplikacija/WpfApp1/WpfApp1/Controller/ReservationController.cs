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
        public List<Reservation> GetAllByGuest(String guestJMBG)
        {
            return this.reservationService.GetAllByGuest(guestJMBG);
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
        public bool CancelReservation(string reservationId)
        {
            return this.reservationService.CancelReservation(reservationId);
        }
        public List<Reservation> GetAllByHotel(String hotelID)
        {
            return this.reservationService.GetAllByHotel(hotelID);
        }
        public void ApproveReservation(string reservationId)
        {
            var reservation = reservationService.GetById(reservationId);
            if (reservation != null)
            {
                reservation.ReservationStatus = ReservationStatus.Approved;
                reservationService.Approve(reservation);
            }
            else
            {
                throw new Exception("Reservation not found.");
            }
        }
        public void RejectReservation(string reservationId, string reason)
        {
            var reservation = reservationService.GetById(reservationId);
            if (reservation != null)
            {
                reservation.ReservationStatus = ReservationStatus.Rejected;
                reservation.RejectionReason = reason;
                reservationService.Reject(reservation);
            }
            else
            {
                throw new Exception("Reservation not found.");
            }
        }
    }
}