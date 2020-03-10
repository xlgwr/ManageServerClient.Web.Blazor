using AutoMapper;
using ManageServerClient.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageServerClient.Web.Blazor.AutoMapper.Profiles
{
    public class ServiceNodeInfoProfile : Profile
    {
        public ServiceNodeInfoProfile()
        {
            CreateMap<ServiceNodeInfo, ServiceNodeInfo>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
