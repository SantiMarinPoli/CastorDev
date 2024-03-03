
using System;
using Castor.EmployeeRecord;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] arg)
    {
        CreateHostBuilder(arg).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}
