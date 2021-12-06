using Mecanica.API.Data;
using Mecanica.API.Data.Entities;
using Mecanica.API.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mecanica.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //1. INYECTANDO MI USER AL SISTEMA 
            services.AddIdentity<User, IdentityRole>(x =>
             {
                 x.User.RequireUniqueEmail=true;
                 x.Password.RequireDigit = false;
                 x.Password.RequiredUniqueChars = 0;
                 x.Password.RequireLowercase = false;
                 x.Password.RequireNonAlphanumeric = false;
                 x.Password.RequireUppercase = false;             
             }).AddEntityFrameworkStores<DataContext>();

            //inyectando nuestra configuracion a la bd
            services.AddDbContext<DataContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //INYECTANDO EL SEEDER (EL AddTrasient sirve cuando solo lo vamos a inyectar una sola vez)
            services.AddTransient<SeedDb>();
            //3. CONFIGURANDO EL SCOPE
            //************ INYECTO EL USERHELPER
            services.AddScoped<IUserHelper, UserHelper>();
            //************INYECTO EL COMBOSHELPER
            services.AddScoped<ICombosHelper, CombosHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //2. tambien agrego esto despues de implemnetacion de mi User
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
