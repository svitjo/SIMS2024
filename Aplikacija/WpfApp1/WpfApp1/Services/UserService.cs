using ReservationSystem.Model;
using ReservationSystem.Repository;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Service
{
    public class UserService
    {
        public UserRepository userRepository { get; set; }

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public List<User> GetAll()
        {
            return this.userRepository.GetAll();
        }
        public User GetById(String jmbg)
        {
            return this.userRepository.GetById(jmbg);
        }
        public bool Delete(String jmbg)
        {
            // TODO: implement
            return false;
        }
        public bool Update(User user)
        {
            // TODO: implement
            return false;
        }
        public bool Save(User user)
        {
            if (this.userRepository.GetById(user.Jmbg) is null)
            {
                return this.userRepository.Save(user); ;
            }
            return false;
        }
    }
}