using Frontend.Services.Api;
using Frontend_App.Services.Api;

namespace Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddHttpClient();
            builder.Services.AddScoped<ProductApi>();
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddScoped<MessageApi>();

            builder.Services.AddControllersWithViews();


            var app = builder.Build();
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
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