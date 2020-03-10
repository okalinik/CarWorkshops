using CarWorkshops.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWorkshops.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllBrands();
    }
}
