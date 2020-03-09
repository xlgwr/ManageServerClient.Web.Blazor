using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageServerClient.Web.Blazor.ApiController
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class ServiceNodeController : ControllerBase
    {
        public static List<ServiceNodeInfo> tmpList = new List<ServiceNodeInfo>()
        {
            new ServiceNodeInfo(){ identity=Guid.NewGuid().ToString(), svrid="1", desc="测试1" },
            new ServiceNodeInfo(){ identity=Guid.NewGuid().ToString(), svrid="2", desc="测试2" }
        };
        // GET: api/ServiceNode
        [HttpGet]
        public ResponseObject<List<ServiceNodeInfo>> TE_ALL_SVR_QRY([FromQuery]RequestBase requestBase)
        {
            var result = new ResponseObject<List<ServiceNodeInfo>>();
            if (requestBase.reqid == ServerEnum.TE_ALL_SVR_QRY)
            {
                result.databody = tmpList.OrderBy(a => a.svrid).ToList();
                return result;
            }
            result.errinfo = "请求服务号错误:" + requestBase.toJsonStr();
            result.errcode = -1;

            return result;
        }

        // GET: api/ServiceNode/5
        [HttpGet("{svrid}", Name = "TE_ALL_SVR_QRY")]
        public ServiceNodeInfo TE_ALL_SVR_QRY(string svrid)
        {
            return tmpList.Where(a => a.svrid == svrid).FirstOrDefault();
        }

        // POST: api/ServiceNode
        [HttpPost]
        public ResponseObject<ServiceNodeInfo> TE_SVR_CFG_UPD(RequestObject<ServiceNodeInfo> requestBase)
        {
            var result = new ResponseObject<ServiceNodeInfo>()  ;
             
            if (requestBase.reqid == ServerEnum.TE_SVR_CFG_UPD)
            {
                var getId = tmpList.Where(a => a.identity == requestBase.identity).FirstOrDefault();
                if (getId != null)
                {
                    tmpList.Remove(getId);
                    requestBase.databody.identity = requestBase.identity;
                    tmpList.Add(requestBase.databody);
                }
                else
                {
                    result.errcode = -1;
                    result.errinfo = "请求数据不存在";
                }
                return result;
            }

            result.errinfo = "请求服务号错误";
            result.errcode = -1;
            return result;
        }

        // PUT: api/ServiceNode/5
        [HttpPut]
        public ResponseObject<ServiceNodeInfo> TE_SVR_ADD(RequestObject<ServiceNodeInfo> requestBase)
        {
            var result = new ResponseObject<ServiceNodeInfo>() { databody = new ServiceNodeInfo() };

            var newGuid = Guid.NewGuid().ToString();
            if (requestBase.reqid == ServerEnum.TE_SVR_ADD)
            {
                var newValue = requestBase.databody;
                newValue.identity = newGuid;
                tmpList.Add(newValue);

                result.databody.identity = newGuid;
                return result;
            }

            result.errinfo = "请求服务号错误";
            result.errcode = -1;
            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public ResponseObject<ServiceNodeInfo> TE_SVR_OPER(RequestBase requestBase)
        {
            var result = new ResponseObject<ServiceNodeInfo>();
            if (requestBase.reqid == ServerEnum.TE_SVR_OPER)
            {
                var getId = tmpList.Where(a => a.identity == requestBase.identity).FirstOrDefault();
                if (getId == null)
                {
                    result.errinfo = "请求数据不存在:" + requestBase.toJsonStr();
                    result.errcode = -1;
                    return result;
                }
                getId.svrOper = requestBase.cmd;
                result.errinfo = requestBase.cmd.GetDescription() + "成功";
                return result;
            }
            result.errinfo = "请求服务号错误:" + requestBase.toJsonStr();
            result.errcode = -1;

            return result;
        }
    }
}
