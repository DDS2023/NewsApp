using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Themes
{
    public class ThemeDTO: EntityDto <int> 
    {
        public string Descripcion { get; set }
        public string Etiqueta { get; set; }
    }
}
