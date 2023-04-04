using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoWeb.Infra.Ioc.AutoMapper.Configuration;

public class AutoMapperConfiguration
{
    public static MapperConfiguration RegisterMappings()
        => new(mc =>
        {
            mc.AddProfile(new DtoToDomain());
        });
}
