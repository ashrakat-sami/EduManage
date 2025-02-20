using EduManage.Data;
using EduManage.Services;

namespace EduManage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(c =>
            {
                c.UseSqlServer(builder.Configuration.GetConnectionString("conection"));
            });
            //Dependency injection
            builder.Services.AddSingleton<IDepartment, DepartmentService>();
            builder.Services.AddSingleton<IStudent, StudentService>();
            var app = builder.Build();
           
           
            #region Try Middleware
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("First middleware:Short circuit");
            //});
            //app.Use(async ( context, next) =>
            //{
            //    await context.Response.WriteAsync("Second middleware");
            //    await next();
            //});

            #endregion
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");  //handle exception in production environment
                //must be first middleware
            }
            app.UseHttpsRedirection();  //if the request is http turn it int https to be more secure
            app.UseStaticFiles();  //if request demand a static file , it searches for it in wwwroot

            app.UseRouting(); //search for controller's name and action's name pbassed on the pattern
            //must be before UseAuthorization

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
