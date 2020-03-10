using ManageServerClient.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageServerClient.Shared.Entity
{
    /// <summary>
    /// 请求参数基类
    /// </summary>
    public class RequestBase
    {
        public ServerEnum reqid { get; set; }

        #region 4.1.3 激活/停止/删除服务节点

        public SVR_OPER cmd { get; set; }
        public string identity { get; set; }
        #endregion
    }
}
