using CarWorkshops.Database;
using CarWorkshops.Domain.Models;
using CarWorkshops.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshops.Services
{
    public class BrandService : IBrandService
    {
        private IDBContext _dbContext;

        public BrandService(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<Brand>> GetAllBrands()
                => Task.Run(() => (IEnumerable<Brand>)_dbContext.Brands.ToList());
    }
}
