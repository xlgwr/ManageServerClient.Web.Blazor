using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
    public static class jsRuntimeExt
    {
        /// <summary>
        /// bootstrap  模态框 modal.js
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="id"></param>
        /// <param name="options"></param>
        public static void modalJs(this IJSRuntime jsRuntime, string id, string options, string funName = "modalJs")
        {
            jsRuntime.InvokeVoidAsync($"exampleJsFunctions.{funName}", id, options);
        }
        /// <summary>
        /// 触发 focus 事件
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="id"></param>
        /// <param name="options"></param>
        /// <param name="funName"></param>
        public static void onfocusJs(this IJSRuntime jsRuntime, string id, string funName = "onfocusJs")
        {
            jsRuntime.InvokeVoidAsync($"exampleJsFunctions.{funName}", id);
        }
    }
}
