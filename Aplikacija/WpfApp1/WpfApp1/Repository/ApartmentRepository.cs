/***********************************************************************
 * Module:  ApartmentRepository.cs
 * Author:  User
 * Purpose: Definition of the Class Repository.ApartmentRepository
 ***********************************************************************/

using ReservationSystem.Model;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Repository
{
   public class ApartmentRepository
   {
      public Model.Apartment GetById(String name)
      {
         // TODO: implement
         return null;
      }
      
      public bool Save(Model.Apartment apartment)
      {
         // TODO: implement
         return false;
      }
      
      public List<Apartment> GetAllByHotel(String id)
      {
         // TODO: implement
         return null;
      }
   
      private String FileLocation;
   
   }
}