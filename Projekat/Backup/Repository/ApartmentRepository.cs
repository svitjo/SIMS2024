/***********************************************************************
 * Module:  ApartmentRepository.cs
 * Author:  User
 * Purpose: Definition of the Class Repository.ApartmentRepository
 ***********************************************************************/

using System;

namespace Repository
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