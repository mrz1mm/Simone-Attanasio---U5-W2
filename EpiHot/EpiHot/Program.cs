using EpiHot.Services;
using InputValidation.Services;

namespace EpiHot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();

            builder.Services
                .AddScoped<AuthSvc>()
                .AddScoped<CheckoutSvc>()
                .AddScoped<CsvCitySvc>()
                .AddScoped<CustomerSvc>()
                .AddScoped<FiscalCodeSvc>()
                .AddScoped<ReservationSvc>()
                .AddScoped<RoomSvc>()
                .AddScoped<ServiceSvc>()
                .AddScoped<UserSvc>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
