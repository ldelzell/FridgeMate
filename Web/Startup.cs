using Microsoft.AspNetCore.Authentication.Cookies;
using MySql.Data.MySqlClient;
using System;

namespace CarMania
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => {
                options.Cookie.Name = "MyAuthCookie";
                options.LoginPath = "/Account/Login";
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:7228", "http://localhost:5287")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });
            services.AddHttpClient("Api1", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7228/");
            });

            services.AddHttpClient("Api2", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5287/");
            });

            services.AddControllersWithViews();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddRazorPages();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowSpecificOrigin");
            app.UseCookiePolicy();
            app.MapRazorPages();
            app.MapGet("/todoitems", (HttpRequest r) =>
            {
                return "dssgd";
            });

            
            app.Run();
        }

    }
}
