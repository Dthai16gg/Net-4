using Web_Application.IServices;
using Web_Application.Services;

namespace Web_Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IProductServices, ProductServices>();
            builder.Services.AddTransient<IUserServices, UserServices>();
            //builder.Services.AddSingleton<IProductServices, ProductServices>();
            //builder.Services.AddScoped<IProductServices, ProductServices>();
            /*
             *AddSingleton : Neu service duoc khoi tao , no co the ton tai cho den khi vong doi cua ung dung ket thuc.
             *Neu cac request khac ma duoc trien khai thi dung lai chinh service do.Phu hop cho cac service co tinh toan cuc va khong thay doi
             *AddScoped    : moi lan co http request thi se tao ra service 1 lan va duoc giu nguyen trong qua trinh request duoc xu ly.Loai nay
             *se duoc su dung cho cac service voi nhung yeu cau http cu the
             *AddTransient : Tao moi service voi moi khi co request. Voi moi yeu cau http se nhan dc 1 doi tuong service khac nhau. phu hop cho cac
             * service ma co the phuc vu nhieu yeu cau http request.
             */
            int timeSession = 15;
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(timeSession);
            });
            //dang ki session voi thoi gian la 15s cho den khi timeout
            var app = builder.Build();//cach session viet truoc dong nay

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}