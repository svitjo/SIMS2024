/***********************************************************************
 * Module:  Hotel.cs
 * Author:  User
 * Purpose: Definition of the Class Model.Hotel
 ***********************************************************************/

using System;

namespace Model
{
   public class Hotel
   {
      public System.Collections.ArrayList user;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetUser()
      {
         if (user == null)
            user = new System.Collections.ArrayList();
         return user;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetUser(System.Collections.ArrayList newUser)
      {
         RemoveAllUser();
         foreach (User oUser in newUser)
            AddUser(oUser);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddUser(User newUser)
      {
         if (newUser == null)
            return;
         if (this.user == null)
            this.user = new System.Collections.ArrayList();
         if (!this.user.Contains(newUser))
            this.user.Add(newUser);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveUser(User oldUser)
      {
         if (oldUser == null)
            return;
         if (this.user != null)
            if (this.user.Contains(oldUser))
               this.user.Remove(oldUser);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllUser()
      {
         if (user != null)
            user.Clear();
      }
   
      private String Id;
      private String Name;
      private int ConstructionYear;
      private int StarRating;
      private String OwnerJMBG;
      private List<Apartment> Apartments;
   
   }
}