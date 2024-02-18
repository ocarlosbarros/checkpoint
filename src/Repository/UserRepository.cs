using System.Linq;
using CheckPoint.Context;
using CheckPoint.Interfaces;

namespace CheckPoint.Repository;

public class UserRepository : IUserRepository
{
    private readonly CheckPointContext _dbContext;

    public UserRepository(CheckPointContext dbContext) => _dbContext = dbContext;
    
    public void CreateUser(User user){}

    public User GetUserBy(string email, string password)
    {
        var user = _dbContext.Users.FirstOrDefault(user => user.Email == email && user.Password == password);

        return user;
    }
}