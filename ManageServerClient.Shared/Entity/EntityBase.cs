using System;
using System.Collections.Generic;
using System.Text;

namespace ManageServerClient.Shared.Entity
{
    public class EntityBase
    {
        /// <summary>
        /// 序号 不序列化
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        //[Newtonsoft.Json.JsonProperty(PropertyName ="@serNo")]    //序列化别名
        public int SerNo { get; set; }
    }
}
