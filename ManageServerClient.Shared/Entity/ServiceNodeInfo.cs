using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Description("服务标识")]
        public string identity { get; set; }
        /// <summary>
        /// 服务id
        /// </summary>
        [Description("服务id")]
        [Required]
        public string svrid { get; set; }
        /// <summary>
        /// 服务类型
        /// </summary>
        [Description("服务类型")]
        [Required]
        public int svrtype { get; set; }
        /// <summary>
        /// 服务ip
        /// </summary>
        [Description("服务ip")]
        [Required]
        public string ip { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        [Description("端口")]
        [Required]
        [Range(0, 65535, ErrorMessage = "Accommodation invalid (0-65535).")]
        public int port { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        public string desc { get; set; }

        /// <summary>
        /// 激活,停止,删除
        /// </summary>
        public SVR_OPER svrOper { get; set; } = SVR_OPER.None;
    }
}
