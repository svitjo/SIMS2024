/***********************************************************************
 * Module:  HotelService.cs
 * Author:  User
 * Purpose: Definition of the Class Services.HotelService
 ***********************************************************************/

using ReservationSystem.Model;
using ReservationSystem.Repository;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Service
{
   public class HotelService
   {
        public HotelRepository hotelRepository;

        public HotelService(HotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public List<Hotel> GetAll()
        {
            return this.hotelRepository.GetAll();
        }
      
        public Hotel GetById(String id)
        {
            return this.hotelRepository.GetById(id);
        }
      
        public bool Update(Hotel hotel)
        {
            // TODO: implement
            return false;
        }
      
        public bool Save(Hotel hotel)
        {
            if (this.hotelRepository.GetById(hotel.Id) is null)
            {
                return this.hotelRepository.Save(hotel); ;
            }
            return false;
        }
      
        public List<Hotel> GetAllByManager(String managerJMBG)
        {
            // TODO: implement
            return null;
        } 
   }
}