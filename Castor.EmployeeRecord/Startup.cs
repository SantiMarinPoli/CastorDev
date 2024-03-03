using Castor.EmployeeRecord.Services;
using Castor.EmployeeRecord.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Castor.EmployeeRecord
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseSqlite("Data Source=LocalDatabase.db"));
            services.AddControllers();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Registro Empleado", Version= "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost4200",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context dbcontext)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Registro Empleado V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/swagger");
                }
                else
                {
                    await next();
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("AllowLocalhost4200");

            app.UseRouting();

            app.UseAuthorization();

            dbcontext.Database.EnsureCreated();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Configura las rutas de los controladores
            });

        }
    }
}
