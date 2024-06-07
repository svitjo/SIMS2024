using Newtonsoft.Json;
using ReservationSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReservationSystem.Repository
{
    public class ApartmentRepository
    {
        private String fileLocation;

        public ApartmentRepository(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }
        public Apartment GetById(String name)
        {
            var values = this.GetAll();
            return values.Find(value => name.Equals(value.Name));
        }
        public bool Save(Apartment apartment)
        {
            bool isSaved = false;
            var values = this.GetAll();
            var found = values.FindIndex(value => apartment.Name.Equals(value.Name));
            if (found != -1)
            {
                values[found] = apartment;
            }
            else
            {
                values.Add(apartment);
                isSaved = true;
            }
            File.WriteAllText(fileLocation, JsonConvert.SerializeObject(values, Formatting.Indented));
            return isSaved;
        }
        public List<Apartment> GetAllByHotel(String id)
        {
            var values = this.GetAll();
            return values.FindAll(value => id.Equals(value.HotelID));
        }
        public List<Apartment> GetAll()
        {
            var values = JsonConvert.DeserializeObject<List<Apartment>>(File.ReadAllText(fileLocation));
            if (values == null)
            {
                values = new List<Apartment>();
            }
            return values;
        }
    }
}