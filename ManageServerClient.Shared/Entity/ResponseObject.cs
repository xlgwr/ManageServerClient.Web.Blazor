using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageServerClient
{
    /// <summary>
    /// 数据响应实体类  生成实体时传入实际的实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseObject<T> : ResponseBase
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        public T databody { get; set; } = default(T);
    }
}
