using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CORE_BookStore.Components;
using CORE_BookStore.Data;
using CORE_BookStore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace CORE_BookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            //Provide connection String to DbContextOptions class parameter that is used by DbContext class to establish the connection to the database
            services.AddDbContext<BookStoreContext>(options =>options.UseSqlServer(@"Server=DESKTOP-A72R8Q6\SQLEXPRESS;Database=SajaBooks;Integrated Security=True"));

            //add MVC templates to the project
            services.AddControllersWithViews();     
            //add razor page compilation during runtime
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //to disable client side validation
            //.AddViewOptions(option => {option.HtmlHelperOptions.ClientValidationEnabled = false; }
#endif
            services.AddScoped<BookRepository, BookRepository>();
            services.AddScoped<LanguageRepository, LanguageRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //enables routing
            app.UseRouting();

            //to support static file we need a middleware
            app.UseStaticFiles(); //support wwwroot file

            //also to enable routing 
            app.UseEndpoints(endpoints => endpoints.MapControllerRoute( name:"Default" , pattern: "{Controller=Book}/{Action=GetAllBook}/{id?}"));
            
            //app.UseEndpoints(endpoint =>  endpoint.MapDefaultControllerRoute());
        }
    }
}
