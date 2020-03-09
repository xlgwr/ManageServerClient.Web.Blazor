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
        [HttpGet("ServiceNode/TE_ALL_SVR_QRY")] 
        ITask<ResponseObject<List<ServiceNodeInfo>>> TE_ALL_SVR_QRY(RequestBase request);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ServiceNode/TE_SVR_CFG_UPD")]
        ITask<ResponseObject<ServiceNodeInfo>> TE_SVR_CFG_UPD(RequestObject<ServiceNodeInfo> request);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("ServiceNode/TE_SVR_ADD")]
        ITask<ResponseObject<ServiceNodeInfo>> TE_SVR_ADD([JsonContent]RequestObject<ServiceNodeInfo> request);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("ServiceNode/TE_SVR_OPER")]
        ITask<ResponseObject<ServiceNodeInfo>> TE_SVR_OPER(RequestBase request);



    }
}
