using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebSite.AppServices.FriendList;
using WebSite.AppServices.FriendRequestAppService;
using WebSite.AppServices.LogIn;
using WebSite.AppServices.MailVerification;
using WebSite.AppServices.Profile;
using WebSite.AppServices.Registration;
using WebSite.AppServices.Reviews;
using WebSite.AppServices.UserAppService;
using WebSite.EntityFramework.DbContext;
using WebSite.Hubs;
using WebSite.Infrastructure;
using WebSite.Models;

namespace WebSite
{
    public class Startup
    {
        public readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("DefaultDb")));
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IRegistrationInfo, RegistrationInfo>();
            services.AddTransient<ILogIn, Login>();
            services.AddTransient<IMailVerification, MailVerification>();
            services.AddTransient<IProfileInfo, ProfileInfo>();
            services.AddTransient<IFriendRequest, FriendRequest>();
            services.AddTransient<IFriendList, FriendList>();
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IReview, Review>();

            services.AddAuthentication();

            services.AddSignalR();

            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;

                
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Home/Registration";
            });

            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "244768494347087";
                options.AppSecret = "ff37bff7443b7e35127b7051d74a8069";
            }).AddGoogle(options =>
            {
                options.ClientId = "303683075560-8gn3smfjfrhmhvpqprc6ukfmcfvknme3.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapHub<PostHub>("/postHub");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{Id?}");

            });
            

        }
    }
}
