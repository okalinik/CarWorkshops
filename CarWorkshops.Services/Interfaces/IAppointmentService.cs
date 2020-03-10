using CarWorkshops.Domain.Models;
using CarWorkshops.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWorkshops.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task CreateAppointment(Appointment appointment);
        Task ChangeDateTimeAppointment(int appId, DateTime datetime);
        Task RemoveAppointment(Appointment appointment);
        Task<IEnumerable<AppoinmentViewModel>> GetAllAppoinments();
    }
}
