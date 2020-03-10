using CarWorkshops.Database;
using CarWorkshops.Domain.Models;
using CarWorkshops.Domain.Models.ViewModels;
using CarWorkshops.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshops.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IDBContext _dbContext;

        public AppointmentService(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeDateTimeAppointment(int appId, DateTime datetime)
          => await Task.Run(() =>
                {
                    var app = _dbContext.Appointments.FirstOrDefault(z => z.Id == appId);
                    app.DateTime = datetime;
                    //Save Changes 
                });


        public async Task CreateAppointment(Appointment appointment)
         => await Task.Run(() => _dbContext.Appointments.ToList().Add(appointment));

        public async Task RemoveAppointment(Appointment appointment)
          => await Task.Run(() => _dbContext.Appointments.ToList().Remove(appointment));

        public Task<IEnumerable<AppoinmentViewModel>> GetAllAppoinments()
              => Task.Run(() =>
                     {
                         return from a in _dbContext.Appointments
                                join u in _dbContext.Users on a.UserID equals u.Id
                                join workshop in _dbContext.Workshops
                                on a.CompanyId equals workshop.Id
                                select new AppoinmentViewModel
                                {
                                    Id = a.Id,
                                    CompanyId = workshop.Id,
                                    CompanyName = workshop.CompanyName,
                                    UserID = u.Id,
                                    Username = u.Username,
                                    UsersCarTrademark = workshop.CarTrademarksSpecializes,
                                    DateTime = a.DateTime
                                };
                     });
    }
}