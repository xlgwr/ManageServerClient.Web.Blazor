using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace ManageServerClient.Web.Blazor
{
    public class Program
    {
        const string outputTemplate = "[{Timestamp:HH:mm:ss.FFF} {Level}] {Message} ({SourceContext:l}){NewLine}{Exception}";
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            // Add this line:
            .WriteTo.File(
                @"log\myappMain.log",
                fileSizeLimitBytes: 1_000_000,
                rollOnFileSizeLimit: true,
                rollingInterval: RollingInterval.Day,
                outputTemplate: outputTemplate,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1))
            .WriteTo.File(
                @"log\myappMain.error.log",
                LogEventLevel.Error,
                fileSizeLimitBytes: 1_000_000,
                rollOnFileSizeLimit: true,
                outputTemplate: outputTemplate,
                rollingInterval: RollingInterval.Day,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1))
            .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                Log.Error("Starting web host test error");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                     .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    // Add this line:
                    .WriteTo.File(
                        @"log\myapp.log",
                        fileSizeLimitBytes: 1_000_000,
                        rollOnFileSizeLimit: true,
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: outputTemplate,
                        shared: true,
                        flushToDiskInterval: TimeSpan.FromSeconds(1))
                    .WriteTo.File(
                        @"log\myapp.error.log",
                        LogEventLevel.Error, 
                        fileSizeLimitBytes: 1_000_000,
                        rollOnFileSizeLimit: true,
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: outputTemplate,
                        shared: true,
                        flushToDiskInterval: TimeSpan.FromSeconds(1))
             ); // <-- Add this line;;
    }
}
