using System;
using CheckPoint.Enums;

namespace CheckPoint.Interfaces;

public interface IUserService {

        public User CreateUser(User user);
        public User GetUserBy(string email, string password);
        
}