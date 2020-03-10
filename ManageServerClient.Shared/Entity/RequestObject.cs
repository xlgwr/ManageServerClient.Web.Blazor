using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageServerClient.Shared.Entity
{
    public class RequestObject<T> : RequestBase
    {
        /// <summary>
        /// 数据实体
        /// </summary>
        public T databody { get; set; }
    }
}
