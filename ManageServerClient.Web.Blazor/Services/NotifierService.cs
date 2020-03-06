 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageServerClient.Web.Blazor.Services
{
    public class NotifierService
    {
        // Can be called from anywhere
        public async Task Update(string key, int value, alertEnum alert)
        {
            if (Notify != null)
            {
                await Notify.Invoke(key, value, alert);
            }
        }

        public event Func<string, int, alertEnum, Task> Notify;
    }
}
