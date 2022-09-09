﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


public class UserService
    {
        private IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public User GetUserById(int userId)
        {
            return _repo.GetUser(userId);
        }

        public void CreateUser(string email)
        {
            _repo.CreateUser(email);
        }

        public void UpdateUser(User user)
        {
            _repo.UpdateUser(user);
        }
    }

