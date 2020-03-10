using CarWorkshops.Database;
using CarWorkshops.Services;
using CarWorkshops.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public static class RegisteredServices
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(IDBContext), typeof(DBContext), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IUserService), typeof(UserService), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IWorkshopService), typeof(WorkshopService), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IBrandService), typeof(BrandService), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IAppointmentService), typeof(AppointmentService), ServiceLifetime.Transient));
        }
    }
}
