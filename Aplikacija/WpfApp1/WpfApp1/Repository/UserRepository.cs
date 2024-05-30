/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  User
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using ReservationSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ReservationSystem.Repository
{
   public class UserRepository
   {
        private String fileLocation;

        public UserRepository(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        public User GetById(String jmbg)
        {
            var values = this.GetAll();
            return values.Find(value => jmbg.Equals(value.Jmbg));
        }

        public List<User> GetAll()
        {
            var values = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(fileLocation));
            if (values == null)
            {
                values = new List<User>();
            }
            return values;
        }

        public bool Save(User user)
        {
            bool isSaved = false;
            var values = this.GetAll();
            var found = values.FindIndex(value => user.Jmbg.Equals(value.Jmbg));
            if (found != -1)
            {
                values[found] = user;
            }
            else
            {
                values.Add(user);
                isSaved = true;
            }
            File.WriteAllText(fileLocation, JsonConvert.SerializeObject(values, Formatting.Indented));
            return isSaved;
        }

        public bool DeleteById(String id)
        {
            // TODO: implement
            return false;
        }
   }
}