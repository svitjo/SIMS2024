/***********************************************************************
 * Module:  Apartment.cs
 * Author:  User
 * Purpose: Definition of the Class Model.Apartment
 ***********************************************************************/

using System;

namespace ReservationSystem.Model
{
   public class Apartment
   {
      public System.Collections.ArrayList hotel;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetHotel()
      {
         if (hotel == null)
            hotel = new System.Collections.ArrayList();
         return hotel;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetHotel(System.Collections.ArrayList newHotel)
      {
         RemoveAllHotel();
         foreach (Hotel oHotel in newHotel)
            AddHotel(oHotel);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddHotel(Hotel newHotel)
      {
         if (newHotel == null)
            return;
         if (this.hotel == null)
            this.hotel = new System.Collections.ArrayList();
         if (!this.hotel.Contains(newHotel))
            this.hotel.Add(newHotel);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveHotel(Hotel oldHotel)
      {
         if (oldHotel == null)
            return;
         if (this.hotel != null)
            if (this.hotel.Contains(oldHotel))
               this.hotel.Remove(oldHotel);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllHotel()
      {
         if (hotel != null)
            hotel.Clear();
      }
   
      private String Name;
      private String Description;
      private int NumberOfRooms;
      private int MaxGuests;
      private String HotelID;
   
   }
}