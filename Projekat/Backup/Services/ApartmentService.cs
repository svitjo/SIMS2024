/***********************************************************************
 * Module:  ApartmentService.cs
 * Author:  User
 * Purpose: Definition of the Class Services.ApartmentService
 ***********************************************************************/

using System;

namespace Services
{
   public class ApartmentService
   {
      public List<Apartment> GetAll()
      {
         // TODO: implement
         return null;
      }
      
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
      
      public int Update(Model.Apartment apartment)
      {
         // TODO: implement
         return 0;
      }
      
      public List<Apartment> GetAllByHotel(String id)
      {
         // TODO: implement
         return null;
      }
   
      public Repository.ApartmentRepository apartmentRepository;
   
   }
}