using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageServerClient
{
    public class ServiceNodeInfo
    {
        /// <summary>
        /// 服务标识
        /// </summary>
        public string identity { get; set; }
        /// <summary>
        /// 服务id
        /// </summary>
        public string svrid { get; set; }
        /// <summary>
        /// 服务类型
        /// </summary>
        public int svrtype { get; set; }
        /// <summary>
        /// 服务ip
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public string port { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string desc { get; set; }
    }
}
