using AutoMapper;
using NewsApp.Alerts;
using NewsApp.RelationNewThemes;
using NewsApp.Themes;
using NewsApp.Users;
using NewsApp.Lists;
using NewsApp.News;
using NewsApp.Searches;
using NewsApp.RelationSearchNews;

namespace NewsApp;

public class NewsAppApplicationAutoMapperProfile : Profile
{
    public NewsAppApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        /* Sirve pasar una entidad de dominio a una DTO, podrían agregarse configuraciones, transformaciones o cambios en los datos */

        CreateMap<Alert, AlertDto>();
        CreateMap<Theme, ThemeDTO>();
        CreateMap<Lista, ListaDto>();
        CreateMap<New, NewDto>();
        CreateMap<Search, SearchDto>();
        CreateMap<SearchNew, SearchNewDto>();
        CreateMap<NewTheme, NewThemeDto>();
        CreateMap<ApplicationUser, ApplicationUserDto>();

    }
}

