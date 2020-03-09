using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ManageServerClient.Web.Blazor.Data;
using WebApiClient;
using Serilog;
using Serilog.Events;
using ManageServerClient.Web.Blazor.Filters;
using Microsoft.AspNetCore.Mvc;
using ManageServerClient.Web.Blazor.Services;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace ManageServerClient.Web.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
                    loggingBuilder.AddSerilog(dispose: true));

            string getUrlHttp = Configuration.GetValue<string>("IServerApiURL");
            HttpApi.Register<IServerApi>().ConfigureHttpApiConfig(c =>
            {
                c.HttpHost = new Uri(getUrlHttp);
                c.FormatOptions.DateTimeFormat = DateTimeFormats.ISO8601_WithMillisecond;
            });

            services.AddHttpClient<IServerApi>().AddTypedClient<IServerApi>((client, p) =>
            {
                return HttpApi.Resolve<IServerApi>();
            });
            //autoMap
            var myAssembly = "ManageServerClient.Web.Blazor";
            var configautoMap = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(myAssembly);
            });
            services.AddSingleton(configautoMap);

            services.AddSingleton<AutoMapService>();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<NotifierService>();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddMvc(options =>
            {
                // 添加全局异常
                options.Filters.Add<HttpResponseExceptionFilter>();

            });//.SetCompatibilityVersion(CompatibilityVersion.Version_3_0); ;

            //禁用默认行为
            services.Configure<ApiBehaviorOptions>(options =>
            {
                //options.SuppressModelStateInvalidFilter = true;
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var error = context.ModelState;
                    try
                    {
                        var errmsgs = new List<string>();
                        foreach (var item in error.Values)
                        {
                            errmsgs.Add(item.Errors.First().ErrorMessage);
                        }
                        int allCount = 0;
                        var ErrorDic = new Dictionary<string, string>();
                        foreach (var item in error.Keys)
                        {
                            ErrorDic[item] = errmsgs[allCount];
                            allCount++;
                        }
                        var result = new ResponseObject<object>()
                        {
                            errcode = -1,
                            errinfo = $"参数验证不通过",
                            errbody = ErrorDic
                        };
                        return new JsonResult(result);
                    }
                    catch (Exception)
                    {
                        var result = new ResponseObject<object>()
                        {
                            errcode = -1,
                            errinfo = $"参数验证不通过",
                            errbody = error
                        };
                        return new JsonResult(result);
                    }
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSerilogRequestLogging(options =>
            {
                // Customize the message template
                options.MessageTemplate = "Handled {RequestPath}";

                // Emit debug-level events instead of the defaults
                options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;

                // Attach additional properties to the request completion event
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                };
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
