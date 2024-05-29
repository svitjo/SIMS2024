/***********************************************************************
 * Module:  GuestRepository.cs
 * Author:  User
 * Purpose: Definition of the Class Repository.GuestRepository
 ***********************************************************************/

using ReservationSystem.Model;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Repository
{
   public class ReservationRepository
   {
      public List<Reservation> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public bool Save(Model.Reservation reservation)
      {
         // TODO: implement
         return false;
      }
      
      public List<Reservation> GetAllByGuest(String guestJMBG)
      {
         // TODO: implement
         return null;
      }
      
      public List<Reservation> GetAllByHotel(String id)
      {
         // TODO: implement
         return null;
      }
      
      public bool Update(Model.Reservation reservation)
      {
         // TODO: implement
         return false;
      }
   
      private String FileLocation;
   
   }
}