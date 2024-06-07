using ReservationSystem.Model;
using ReservationSystem.Repository;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Service
{
    public class UserService
    {
        public UserRepository userRepository;

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
        public bool Save(User user)
        {
            if (this.userRepository.GetById(user.Jmbg) is null)
            {
                return this.userRepository.Save(user);
            }
            return false;
        }
        public User GetByEmail(String email)
        {
            return this.userRepository.GetByEmail(email);
        }
        public bool Block(User user)
        {
            if (this.userRepository.GetById(user.Jmbg) is null)
            {
                return false;
            }
            return this.userRepository.Save(user);
        }
    }
}