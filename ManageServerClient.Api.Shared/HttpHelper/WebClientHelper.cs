using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace ManageServerClient
{
    /// <summary>
    /// 测试http需要部署相应的服务，否则不通过
    /// </summary>
    public class WebClientHelper
    {
        #region 测试示例
        /// <summary>
        /// 获取服务信息
        /// </summary>
        /// <returns></returns>
        public static ITask<string[]> GetServerAsync()
        {
            var api = HttpApi.Resolve<IServerApi>();
            return api.GetAsync("laojiu");
        }

        /// <summary>
        /// 更改服务信息
        /// </summary>
        /// <param name="serverInfo"></param>
        /// <returns></returns>
        public static ITask<string> PostServerAsync(ServerInfo serverInfo)
        {
            var api = HttpApi.Resolve<IServerApi>();
            return api.AddAsync(serverInfo);
        }

        #endregion

        /// <summary>
        /// api配置
        /// </summary>
        public static void ConfigWebApi()
        {
            HttpApi.Register<IServerApi>().ConfigureHttpApiConfig(c =>
            {
                c.HttpHost = new Uri("https://localhost:44310/");
                c.FormatOptions.DateTimeFormat = DateTimeFormats.ISO8601_WithMillisecond;
               // c.GlobalFilters.Add(new ApiTokenFilter());
                //c.FormatOptions = new FormatOptions() { UseCamelCase = true, DateTimeFormat = DateTimeFormats.ISO8601_WithoutMillisecond, IgnoreNullProperty = true };
            });
        }

        public static ITask<ResponseObject<List<ServiceNodeInfo>>> TE_ALL_SVR_QRY(RequestBase request)
        {
            var api = HttpApi.Resolve<IServerApi>();
            return api.TE_ALL_SVR_QRY(request);
        }


    }
}
