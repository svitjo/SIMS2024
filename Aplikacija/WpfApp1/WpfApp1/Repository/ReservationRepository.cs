using Newtonsoft.Json;
using ReservationSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReservationSystem.Repository
{
    public class ReservationRepository
    {
        private String fileLocation;

        public ReservationRepository(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }
        public List<Reservation> GetAll()
        {
            var values = JsonConvert.DeserializeObject<List<Reservation>>(File.ReadAllText(fileLocation));
            if (values == null)
            {
                values = new List<Reservation>();
            }
            return values;
        }
        public bool Save(Reservation reservation)
        {
            bool isSaved = false;
            var values = this.GetAll();
            var found = values.FindIndex(value => reservation.Id.Equals(value.Id));
            if (found != -1)
            {
                values[found] = reservation;
            }
            else
            {
                values.Add(reservation);
                isSaved = true;
            }
            File.WriteAllText(fileLocation, JsonConvert.SerializeObject(values, Formatting.Indented));
            return isSaved;
        }
        public List<Reservation> GetAllByGuest(String guestJMBG)
        {
            var values = this.GetAll();
            return values.FindAll(value => guestJMBG.Equals(value.GuestJMBG));
        }
        public List<Reservation> GetAllByHotel(String hotelID)
        {
            var values = this.GetAll();
            return values.FindAll(value => hotelID.Equals(value.HotelID));
        }
        public Reservation GetById(String id)
        {
            var values = this.GetAll();
            return values.Find(value => id.Equals(value.Id));
        }
        public bool ReservationExists(string apartmentId, DateTime date)
        {
            var values = this.GetAll();
            var filter = values.Find(value => apartmentId.Equals(value.ApartmentID) && date.Date.Equals(value.Date.Date));
            return filter != null;
        }
        public bool CancelReservation(string id)
        {
            var values = this.GetAll();
            var found = values.FindIndex(value => id.Equals(value.Id));
            if (found != -1)
            {
                values[found].ReservationStatus = ReservationStatus.Cancelled;
                File.WriteAllText(fileLocation, JsonConvert.SerializeObject(values, Formatting.Indented));
                return true;
            }
            return false;
        }
    }
}