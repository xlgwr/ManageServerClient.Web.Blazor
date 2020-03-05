using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageServerClient
{
    public enum ServerEnum
    {
        /// <summary>
        /// 查询所有添加到监控平台的服务节点 http
        /// </summary>
        TE_ALL_SVR_QRY = 70001,
        /// <summary>
        /// 添加服务节点 http
        /// </summary>
        TE_SVR_ADD = 70002,
        /// <summary>
        /// 激活/停止/删除服务节点 http
        /// </summary>
        TE_SVR_DEL = 70003,
        /// <summary>
        /// 同步服务节点 socket
        /// </summary>
        TE_SVR_SYN = 70004,
        /// <summary>
        /// 查询服务节点配置信息 http
        /// </summary>
        TE_SVR_CFG_QRY = 70005,
        /// <summary>
        /// 修改服务节点 http
        /// </summary>
        TE_SVR_CFG_UPD = 70006,
        /// <summary>
        /// 配置项同步 socket
        /// </summary>
        TE_SVR_CFG_SYN = 70007,
        /// <summary>
        /// 4.1.8其他业务（获取性能指标等）  http
        /// </summary>
        TE_SVR_CMD = 70008,

    }
}
