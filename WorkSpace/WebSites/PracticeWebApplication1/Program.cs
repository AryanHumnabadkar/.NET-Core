namespace PracticeWebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles(); //=> Static Files Usage

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute( //Mapping All possible routes from the request
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}");

            /* All Possible URL : 
             * www.xyx.com/Home/Index/1
             * www.xyz.com/Home/Index
             * www.xya.com/Home
             * www.xyz.com
             * www.xyz.com/Employee/DisplaySingle/1
             * www.xyz.com/Employee/DisplayAll
            */
            app.Run();
        }
    }
}
