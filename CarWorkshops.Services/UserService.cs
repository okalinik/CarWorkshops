using CarWorkshops.Database;
using CarWorkshops.Domain.Models;
using CarWorkshops.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshops.Services
{
    public class UserService : IUserService
    {
        private IDBContext _dbContext;

        public UserService(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUser(User user)
         => await Task.Run(() => _dbContext.Users.ToList().Add(user));

        public async Task RemoveUser(User user)
         => await Task.Run(() => _dbContext.Users.ToList().Remove(user));

        public Task<User> GetUserById(int id)
         => Task.Run(() => _dbContext.Users.SingleOrDefault(z => z.Id == id));
    }
}
