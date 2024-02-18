namespace CheckPoint.Interfaces;

public interface IUserRepository
{
    public void CreateUser(User user);
    public User GetUserBy(string email, string password);
}