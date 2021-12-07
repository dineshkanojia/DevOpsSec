using System;
using LibraryApp.Areas.Identity.Data;
using LibraryApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LibraryApp.Areas.Identity.IdentityHostingStartup))]
namespace LibraryApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<LibraryAppAuthContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ConnectionString")));

                services.AddDefaultIdentity<LibraryAppIdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })

                    .AddEntityFrameworkStores<LibraryAppAuthContext>();
            });
        }
    }
}