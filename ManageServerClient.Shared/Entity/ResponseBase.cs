using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageServerClient
{
    /// <summary>
    /// 响应参数基类
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// 错误码，0.成功；非0.错误码
        /// </summary>
        public int errcode { get; set; } = 0;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errinfo { get; set; }

        /// <summary>
        /// http 状态码
        /// </summary>
        public int status { get; set; } = 200;

    }
}
