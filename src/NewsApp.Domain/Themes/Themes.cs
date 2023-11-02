using NewsApp.CategoriesTheme;
using NewsApp.Newss;
using NewsApp.RelationNewThemes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Themes
{
    public class Theme : Entity<int>
    {
        public CategoryEnum Etiqueta { get; set; }
        public string Descripcion { get; set; } //necesario?


        public ICollection<New> Noticias { get; set; }
        //  public ICollection<NewThemes> NoticiaTemas { get; set; }

    }
}
