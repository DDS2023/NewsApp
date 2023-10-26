using NewsApp.News;
using NewsApp.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Newss
{
    public class New : Entity<int>
    {
        public string Titular { get; set; }

        public string Cuerpo { get; set; }

        public DateTime Fecha { get; set; }

        public Idioma Idioma { get; set; }
        public Theme Tema { get; set; }
    }
}
