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
        public int errcode { get; set; }
        public string errinfo { get; set; }

    }
}
