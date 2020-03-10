using CarWorkshops.Database;
using CarWorkshops.Infrastructure.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            RegisterAuthenticateScheme(services);

            services.AddScoped<ApiExceptionFilter>();
            services.AddMemoryCache();


            //register as singleton only for demonstration
            // ObjectDBContext() or SQLDBContext() can be used instead
            services.Add(new ServiceDescriptor(typeof(ICurrentDBContext), typeof(ObjectDBContext), ServiceLifetime.Singleton));

            RegisteredServices.RegisterServices(services);
        }

        private void RegisterAuthenticateScheme(IServiceCollection services)
        {
            string url = "test";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Audience = url;
                options.Authority = url;
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.Request.Path.Value.StartsWith("/test/") && context.Request.Query.TryGetValue("access_token", out StringValues token))
                            context.Token = token;
                        return Task.CompletedTask;
                    }
                };
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
