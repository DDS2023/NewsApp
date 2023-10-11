using AutoMapper;
using NewsApp.Themes;

namespace NewsApp;

public class NewsAppApplicationAutoMapperProfile : Profile
{
    public NewsAppApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        /* Sirve pasar una entidad de dominio a una DTO, podrían agregarse configuraciones, transformaciones o cambios en los datos */

        CreateMap<Theme, ThemeDTO>(); 

    }
}

