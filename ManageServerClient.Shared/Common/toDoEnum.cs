using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ManageServerClient.Shared.Common
{
    /// <summary>
    /// none
    /// add
    /// edit
    /// del
    /// live
    /// </summary>
    public enum toDoEnum
    {

        [Description("None")]
        none = 0,
        [Description("新增")]
        add = 1,
        [Description("修改")]
        edit,
        [Description("删除")]
        del,
        [Description("激活")]
        live,
        [Description("停止")]
        stop
    }
}
