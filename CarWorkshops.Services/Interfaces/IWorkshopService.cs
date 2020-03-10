using CarWorkshops.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWorkshops.Services.Interfaces
{
    public interface IWorkshopService
    {
        Task CreateWorkshop(Workshop wshop);
        Task<Workshop> WorkshopById(int id);
        Task RemoveWorkshop(Workshop wshop);
        Task<IEnumerable<Workshop>> GetWorkhopsByCity(string city);
        Task<int> GetWorkhopsByCityAndTrademarkCount(string city, string trademark);
    }
}
