namespace MercadinhoWeb.Infra.Ioc.AutoMapper.Configuration;

public class AutoMapperConfiguration
{
    public static MapperConfiguration RegisterMappings()
        => new(mc =>
        {
            mc.AddProfile(new DtoToDomain());
        });
}
