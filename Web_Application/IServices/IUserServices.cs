using Web_Application.Models;

namespace Web_Application.IServices
{
  public interface IUserServices
  {
    public bool CreateNewUsers(User User);
    public bool UpdateUser(User User);
    public bool DeleteUser(Guid id);
    public User GetUserById(Guid id);
    public List<User> GetUserByName(string name);
    public List<User> GetAllUsers();
  }
}
