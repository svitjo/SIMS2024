/***********************************************************************
 * Module:  GuestRepository.cs
 * Author:  User
 * Purpose: Definition of the Class Repository.GuestRepository
 ***********************************************************************/

using Newtonsoft.Json;
using ReservationSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReservationSystem.Repository
{
   public class HotelRepository
   {
        private String fileLocation;
        public HotelRepository(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        public List<Hotel> GetAll()
        {
            var values = JsonConvert.DeserializeObject<List<Hotel>>(File.ReadAllText(fileLocation));
            if (values == null)
            {
                values = new List<Hotel>();
            }
            return values;
        }
      
        public bool Save(Hotel hotel)
        {
            bool isSaved = false;
            var values = this.GetAll();
            var found = values.FindIndex(value => hotel.Id.Equals(value.Id));
            if (found != -1)
            {
                values[found] = hotel;
            }
            else
            {
                values.Add(hotel);
                isSaved = true;
            }
            File.WriteAllText(fileLocation, JsonConvert.SerializeObject(values, Formatting.Indented));
            return isSaved;
        }
      
        public Hotel GetById(String id)
        {
            var values = this.GetAll();
            return values.Find(value => id.Equals(value.Id));
        }
      
        public List<Hotel> GetAllByManager(String managerJMBG)
        {
            var values = this.GetAll();
            return values.FindAll(value => managerJMBG.Equals(value.OwnerJMBG));
        } 
   }
}