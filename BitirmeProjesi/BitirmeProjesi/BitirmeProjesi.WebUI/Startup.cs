using BitirmeProjesi.Business.Abstract;
using BitirmeProjesi.Business.Concrete;
using BitirmeProjesi.Data.Abstract;
using BitirmeProjesi.Data.Concrete;
using BitirmeProjesi.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.WebUI
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
            services.AddDbContext<ProjeDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options => { 
                options.SignIn.RequireConfirmedAccount = false; 
                options.SignIn.RequireConfirmedEmail = false;

            }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ProjeDbContext>();

            services.ConfigureApplicationCookie(options => 
            {
                options.LoginPath = "/Auth/Login";
                
            });

            services.AddScoped<IApartmentRepository,ApartmentRepository>();
            services.AddScoped<IApartmentService, ApartmentManager>();

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceService, InvoiceManager>();

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageManager>();

            services.AddScoped<IPaidBillsRepository, PaidBillsRepository>();
            services.AddScoped<IPaidBillsService, PaidBillsManager>();

            services.AddHttpClient<ICreditCardService, CreditCardManager>(options => 
            {
                options.BaseAddress = new Uri(Configuration["CreditCard:Url"]);
            });


            services.AddControllersWithViews();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
               
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            SeedIdentity.Seed(userManager, roleManager, configuration).Wait();
        }
    }
}
