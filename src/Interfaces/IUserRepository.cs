namespace CheckPoint.Interfaces;

public interface IUserRepository
{
    public User GetUserBy(string email, string password);
}