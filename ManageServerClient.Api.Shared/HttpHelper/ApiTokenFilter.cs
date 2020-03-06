using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Contexts;

namespace ManageServerClient
{
    /// <summary>
    /// api token 过滤器
    /// </summary>
    public class ApiTokenFilter : IApiActionFilter
    {
        public Task OnBeginRequestAsync(ApiActionContext context)
        {
            //context.RequestMessage.Headers.Add("token", "token value from filter");
            //context.RequestMessage.Headers.Add("header", "header");
            // do something
            return Task.CompletedTask;
        }

        public Task OnEndRequestAsync(ApiActionContext context)
        {
            // do something
            return Task.CompletedTask;
        }

    }
}
