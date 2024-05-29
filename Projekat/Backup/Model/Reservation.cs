/***********************************************************************
 * Module:  Reservation.cs
 * Author:  User
 * Purpose: Definition of the Class Model.Reservation
 ***********************************************************************/

using System;

namespace Model
{
   public class Reservation
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
      public System.Collections.ArrayList apartment;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetApartment()
      {
         if (apartment == null)
            apartment = new System.Collections.ArrayList();
         return apartment;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetApartment(System.Collections.ArrayList newApartment)
      {
         RemoveAllApartment();
         foreach (Apartment oApartment in newApartment)
            AddApartment(oApartment);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddApartment(Apartment newApartment)
      {
         if (newApartment == null)
            return;
         if (this.apartment == null)
            this.apartment = new System.Collections.ArrayList();
         if (!this.apartment.Contains(newApartment))
            this.apartment.Add(newApartment);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveApartment(Apartment oldApartment)
      {
         if (oldApartment == null)
            return;
         if (this.apartment != null)
            if (this.apartment.Contains(oldApartment))
               this.apartment.Remove(oldApartment);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllApartment()
      {
         if (apartment != null)
            apartment.Clear();
      }
   
      private int Id;
      private DateTime Date;
      private String ApartmentID;
      private ReservationStatus ReservationStatus;
      private String GuestJMBG;
      private String RejectionReason;
   
   }
}