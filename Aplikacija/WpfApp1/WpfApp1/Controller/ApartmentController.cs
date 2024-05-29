/***********************************************************************
 * Module:  GuestRepository.cs
 * Author:  User
 * Purpose: Definition of the Class Repository.GuestRepository
 ***********************************************************************/

using System;

namespace Controller
{
   public class ApartmentController
   {
      public List<Manager> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public bool Create(String name, String description, int numberOfRooms, int maxGuests)
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
   
      public Services.ApartmentService apartmentService;
   
   }
}