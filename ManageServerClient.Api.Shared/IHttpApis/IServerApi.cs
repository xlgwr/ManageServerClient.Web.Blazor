using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace ManageServerClient
{
    public interface IServerApi : IHttpApi
    {
        #region 测试示例
        // GET api/user?account=laojiu
        // Return json或xml内容
        [HttpGet("Home/GetIndex/departId")]
        ITask<string[]> GetAsync(string departId);

        // POST api/user  
        // Body Account=laojiu&password=123456
        // Return json或xml内容
        [HttpPost("Home/SetIndex/departId")]
        ITask<string> AddAsync(ServerInfo departId);
        #endregion  

        /// <summary>
        /// 获取所有服务节点
        /// </summary>
        /// <param name="request">请求列表</param>
        /// <returns></returns>
        [HttpGet("Home/TE_ALL_SVR_QRY/reqid")]
        ITask<ResponseObject<List<ServiceNodeInfo>>> TE_ALL_SVR_QRY(RequestBase request);


    }
}
