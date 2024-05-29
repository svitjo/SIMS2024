/***********************************************************************
 * Module:  GuestRepository.cs
 * Author:  User
 * Purpose: Definition of the Class Repository.GuestRepository
 ***********************************************************************/

using System;

namespace Services
{
   public class UserService
   {
      public List<User> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public Model.User GetById(String jmbg)
      {
         // TODO: implement
         return null;
      }
      
      public bool Delete(String jmbg)
      {
         // TODO: implement
         return false;
      }
      
      public bool Update(Model.User user)
      {
         // TODO: implement
         return false;
      }
      
      public bool Save(Model.User user)
      {
         // TODO: implement
         return false;
      }
   
      public Repository.UserRepository userRepository;
   
   }
}