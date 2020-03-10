
using ManageServerClient.Shared.Common;
using ManageServerClient.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageServerClient.Web.Blazor.Services
{
    public class NotifierService
    {
        // Can be called from anywhere
        public async Task Update(string key, alertEnum alert, int value, IList<ErrorInfo> errorInfos)
        {
            if (Notify != null)
            {
                await Notify.Invoke(key, alert, value, errorInfos);
            }
        }

        public event Func<string, alertEnum, int, IList<ErrorInfo>, Task> Notify;
    }
}
