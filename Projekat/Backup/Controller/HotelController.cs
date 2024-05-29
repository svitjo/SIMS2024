/***********************************************************************
 * Module:  GuestRepository.cs
 * Author:  User
 * Purpose: Definition of the Class Repository.GuestRepository
 ***********************************************************************/

using System;

namespace Controller
{
   public class HotelController
   {
      public List<Manager> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public bool Create(String id, String name, int constructionYear, int starRating, String ownerJMBG)
      {
         // TODO: implement
         return false;
      }
      
      public Manager GetById(String jmbg)
      {
         // TODO: implement
         return null;
      }
      
      public bool DeleteById(String jmbg)
      {
         // TODO: implement
         return false;
      }
   
      public Services.HotelService hotelService;
   
   }
}