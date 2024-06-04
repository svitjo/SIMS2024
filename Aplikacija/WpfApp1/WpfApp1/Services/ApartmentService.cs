using ReservationSystem.Model;
using ReservationSystem.Repository;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Service
{
   public class ApartmentService
   {
        public ApartmentRepository apartmentRepository;

        public ApartmentService(ApartmentRepository apartmentRepository)
        {
            this.apartmentRepository = apartmentRepository;
        }
        public List<Apartment> GetAll()
        {
            return this.apartmentRepository.GetAll();
        }
        public Apartment GetById(String name)
        {
            return this.apartmentRepository.GetById(name);
        }
        public bool Save(Apartment apartment)
        {
            if (this.apartmentRepository.GetById(apartment.Name) is null)
            {
                return this.apartmentRepository.Save(apartment);
            }
            return false;
        }
        public int Update(Apartment apartment)
        {
            // TODO: implement
            return 0;
        }
        public List<Apartment> GetAllByHotel(String id)
        {
            return this.apartmentRepository.GetAllByHotel(id);
        }
    }
}