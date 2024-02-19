using CheckPoint.Interfaces;

namespace CheckPoint.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) => _userRepository = userRepository;

    public void CreateUser(User user)
    {
        _userRepository.CreateUser(user);
    }

    public User GetUserBy(string email, string password)
    {
        var user = _userRepository.GetUserBy(email, password);

        return user;
    }
}