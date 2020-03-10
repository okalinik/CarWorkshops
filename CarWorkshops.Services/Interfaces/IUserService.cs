using CarWorkshops.Domain.Models;
using System.Threading.Tasks;

namespace CarWorkshops.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task<User> GetUserById(int id);
        Task RemoveUser(User user);
    }
}
