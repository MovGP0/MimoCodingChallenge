using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mimo.Backend.Courses;
using Mimo.Backend.Users;
using Mimo.Business.Courses;
using Mimo.Business.Seeder;
using Mimo.Business.UoW;
using Mimo.Business.Users;
using System.Threading.Tasks;

namespace Mimo.Frontend
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            ConfigureDependencyInjection(services);
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddDbContext<UsersContext>(options => 
                options.UseSqlite(Configuration["UsersConnectionString"] ?? "Filename=./Users.db"));

            services.AddDbContext<CoursesContext>(options => 
                options.UseSqlite(Configuration["CoursesConnectionString"] ?? "Filename=./Courses.db"));

            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<ICoursesRepository, CoursesRepository>();
            services.AddTransient<AddLessonUnitOfWork>();
            services.AddTransient<GetArchivementsForUserUnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            app.UseMvc();

            if (env.IsDevelopment())
            {
                ConfigureDevelopmentEnvironmentAsync(app, CancellationToken.None).Wait();
            }
        }

        private static async Task ConfigureDevelopmentEnvironmentAsync(IApplicationBuilder app, CancellationToken cancellationToken)
        {
            app.UseDeveloperExceptionPage();
            
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                await serviceScope.SeedCoursesAsync(cancellationToken);
                await serviceScope.SeedUsersAsync(cancellationToken);

                serviceScope.ServiceProvider.GetService<CoursesContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<UsersContext>().Database.Migrate();
            }
        }
    }
}
