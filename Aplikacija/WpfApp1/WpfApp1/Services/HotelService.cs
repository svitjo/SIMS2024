/***********************************************************************
 * Module:  HotelService.cs
 * Author:  User
 * Purpose: Definition of the Class Services.HotelService
 ***********************************************************************/

using System;

namespace Services
{
   public class HotelService
   {
      public List<Hotel> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public Model.Hotel GetById(String id)
      {
         // TODO: implement
         return null;
      }
      
      public bool Update(Model.Hotel hotel)
      {
         // TODO: implement
         return false;
      }
      
      public bool Save(Model.Hotel hotel)
      {
         // TODO: implement
         return false;
      }
      
      public List<Hotel> GetAllByManager(String managerJMBG)
      {
         // TODO: implement
         return null;
      }
   
      public Repository.HotelRepository hotelRepository;
   
   }
}