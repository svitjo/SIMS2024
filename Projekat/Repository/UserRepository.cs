/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  User
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using System;

namespace Repository
{
   public class UserRepository
   {
      public Model.User GetById(String jmbg)
      {
         // TODO: implement
         return null;
      }
      
      public List<User> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public bool Save(Model.User user)
      {
         // TODO: implement
         return false;
      }
      
      public bool DeleteById(String id)
      {
         // TODO: implement
         return false;
      }
   
      private String FileLocation;
   
   }
}