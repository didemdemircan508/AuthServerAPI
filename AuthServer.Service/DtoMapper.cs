using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyAuthServer.Core.DTOs;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Service
{
    public class DtoMapper:Profile
    {//reveerse tam terside olabilir
        public DtoMapper()
        {
            CreateMap<ProductDto,Product>().ReverseMap();
            CreateMap<UserAppDto,UserApp>().ReverseMap();
            
        }
    }
}
