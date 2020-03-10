using CarWorkshops.Database;
using CarWorkshops.Domain.Models;
using CarWorkshops.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshops.Services
{
    public class WorkshopService : IWorkshopService
    {
        private IDBContext _dbContext;

        public WorkshopService(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateWorkshop(Workshop wshop)
            => await Task.Run(() => _dbContext.Workshops.ToList().Add(wshop));

        public async Task RemoveWorkshop(Workshop wshop)
            => await Task.Run(() => _dbContext.Workshops.ToList().Remove(wshop));

        public Task<Workshop> WorkshopById(int id)
            => Task<Workshop>.Run(() => _dbContext.Workshops.SingleOrDefault(z => z.Id == id));

        public Task<IEnumerable<Workshop>> GetWorkhopsByCity(string city)
            => Task.Run(() => _dbContext.Workshops.Where(z => z.City.Equals(city, StringComparison.InvariantCultureIgnoreCase)));


        public Task<int> GetWorkhopsByCityAndTrademarkCount(string city,string trademark)
            => Task.Run(() => _dbContext.Workshops.Count(z => 
            z.City.Equals(city, StringComparison.InvariantCultureIgnoreCase)
            && z.CarTrademarksSpecializes.Contains(trademark)
            ));
    }
}
