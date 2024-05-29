/***********************************************************************
 * Module:  GuestRepository.cs
 * Author:  User
 * Purpose: Definition of the Class Repository.GuestRepository
 ***********************************************************************/

using System;

namespace Controller
{
   public class UserController
   {
      public List<Guest> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public bool Create(String jmbg, String email, String password, String firstname, String lastname, String phone)
      {
         // TODO: implement
         return false;
      }
      
      public ManagGuester GetById(String jmbg)
      {
         // TODO: implement
         return null;
      }
      
      public bool DeleteById(String jmbg)
      {
         // TODO: implement
         return false;
      }
   
      public Services.UserService userService;
   
   }
}