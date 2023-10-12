using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Themes
{
    public class ThemeAppService :
        CrudAppService<Theme, ThemeDTO, int>, IThemeAppService
    {

        //Lo que esta aca tmb hereda del crud
      
        public ThemeAppService(IRepository<Theme, int> repository)  //IRepository permite interactuar con la BDD para consultar o persistir
            : base(repository)
        { 
            
        }



    }
}
