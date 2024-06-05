using System;
using System.Collections.Generic;
using ReservationSystem.Model;
using ReservationSystem.Service;

namespace ReservationSystem.Controller
{
   public class ApartmentController
   {
        private ApartmentService apartmentService;

        public ApartmentController(ApartmentService apartmentService)
        {
            this.apartmentService = apartmentService;
        }
        public List<Apartment> GetAll()
        {
            return this.apartmentService.GetAll();
        }
        public bool Create(String name, String description, int numberOfRooms, int maxGuests, String hotelID)
        {
            var apartment = new Apartment
            {
                Name = name,
                Description = description,
                NumberOfRooms = numberOfRooms,
                MaxGuests = maxGuests,
                HotelID = hotelID
            };

            return this.apartmentService.Save(apartment);
        }
        public Apartment GetById(String name)
        {
            return this.apartmentService.GetById(name);
        }
        public bool DeleteById(String jmbg)
        {
            // TODO: implement
            return false;
        }
        public List<Apartment> GetAllByHotel(String hotelID)
        {
            return this.apartmentService.GetAllByHotel(hotelID);
        }
    }
}