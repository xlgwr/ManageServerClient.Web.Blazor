using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ManageServerClient.Shared.Common
{
    /// <summary>
    /// alert-success
    /// alert-info
    /// alert-warning
    /// alert-danger
    /// </summary>
    public enum alertEnum
    {
        /// <summary>
        /// alert-success
        /// </summary>
        [Description("alert-success")]
        success = 0,
        [Description("alert-info")]
        info,
        [Description("alert-warning")]
        warning,
        [Description("alert-danger")]
        danger
    }
}
