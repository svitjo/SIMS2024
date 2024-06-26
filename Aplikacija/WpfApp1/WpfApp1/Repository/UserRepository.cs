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
        public User GetByEmail(String email)
        {
            var values = this.GetAll();
            return values.Find(value => email.Equals(value.Email));
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
    }
}