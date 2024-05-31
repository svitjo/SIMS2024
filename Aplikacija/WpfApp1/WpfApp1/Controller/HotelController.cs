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
   public class HotelController
   {
        private HotelService hotelService;
        public HotelController(HotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        public List<Hotel> GetAll()
      {
            return this.hotelService.GetAll();
        }
      
      public bool Create(String id, String name, int constructionYear, int starRating, String ownerJMBG)
      {
         // TODO: implement
         return false;
      }
      
      public User GetById(String jmbg)
      {
         // TODO: implement
         return null;
      }
      
      public bool DeleteById(String jmbg)
      {
         // TODO: implement
         return false;
      }
   
   }
}