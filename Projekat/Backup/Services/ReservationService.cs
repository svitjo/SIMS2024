/***********************************************************************
 * Module:  ReservationService.cs
 * Author:  User
 * Purpose: Definition of the Class Services.ReservationService
 ***********************************************************************/

using System;

namespace Services
{
   public class ReservationService
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
      
      public List<Reservation> GetAllByHotel(String hotelID)
      {
         // TODO: implement
         return null;
      }
      
      public bool Update(Model.Reservation reservation)
      {
         // TODO: implement
         return false;
      }
   
      public Repository.ReservationRepository reservationRepository;
   
   }
}