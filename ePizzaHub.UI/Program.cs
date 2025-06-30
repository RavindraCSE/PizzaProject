using Microsoft.AspNetCore.Authentication.Cookies;

namespace ePizzaHub.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // tell that using cookes auth
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/Login/Login";
                    options.LogoutPath = "/Login/LogOut";
                    
                });
            builder.Services.AddAuthorization();
            //starts:  to congigure the api
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient("ePizzaAPI", options => 
            {
                options.BaseAddress = new Uri(builder.Configuration["ePizzaAPI:Url"]!);
                options.DefaultRequestHeaders.Add("Accept", "application/json");
            });
          
            //ends :  to congigure the api

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // auth
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
