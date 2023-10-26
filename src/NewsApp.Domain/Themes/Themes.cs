using NewsApp.Newss;
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
        public string Descripcion { get; set; }
        public string Etiquetas { get; set; }

        public ICollection<New> News { get; set;}
    }
}
