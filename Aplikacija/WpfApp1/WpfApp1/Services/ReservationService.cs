using ReservationSystem.Model;
using ReservationSystem.Repository;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Service
{
    public class ReservationService
    {
        public ReservationRepository reservationRepository;

        public ReservationService(ReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public List<Reservation> GetAll()
        {
            return this.reservationRepository.GetAll();
        }
        public bool Save(Reservation reservation)
        {
            if (this.reservationRepository.GetById(reservation.Id) is null)
            {
                return this.reservationRepository.Save(reservation);
            }
            return false;
        }
        public List<Reservation> GetAllByGuest(String guestJMBG)
        {
            return this.reservationRepository.GetAllByGuest(guestJMBG);
        }
        public List<Reservation> GetAllByHotel(String hotelID)
        {
            return this.reservationRepository.GetAllByHotel(hotelID);
        }
        public Reservation GetById(String id)
        {
            return this.reservationRepository.GetById(id);
        }
        public bool ReservationExists(string apartmentId, DateTime date)
        {
            return this.reservationRepository.ReservationExists(apartmentId, date);
        }
        public bool CancelReservation(string reservationId)
        {
            return reservationRepository.CancelReservation(reservationId);
        }
        public bool Approve(Reservation reservation)
        {
            if (this.reservationRepository.GetById(reservation.Id) is null)
            {
                return false;
            }
            return this.reservationRepository.Save(reservation);
        }
        public bool Reject(Reservation reservation)
        {
            if (this.reservationRepository.GetById(reservation.Id) is null)
            {
                return false;
            }
            return this.reservationRepository.Save(reservation);
        }
    }
}