using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace NewsApp.Themes
{
    public interface IThemeAppService :         //Definimos el comportamiento de nuestra aplicación
        ICrudAppService<    
            //Define los metodos crud (Create, remove, update y devolution)
            ThemeDTO,       
            int    //el tipo de dato
            //PagedAndSortedResultRequestDto  //Paginado y ordenamiento
            //Si tuvieramos un CreateUpdateDTO iria aca, es el parametro de entrada
            >
    {
        
    }
}
