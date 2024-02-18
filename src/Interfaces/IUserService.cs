namespace CheckPoint.Interfaces;

public interface IUserService {

        public void CreateUser(User user);
        public User GetUserBy(string email, string password);
        
}