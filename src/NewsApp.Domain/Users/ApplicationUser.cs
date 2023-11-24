using NewsApp.Languages;
using NewsApp.List;
using NewsApp.Searches;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace NewsApp.Users
{
    public class ApplicationUser: IdentityUser
    {
        public LanguageEnum Idioma { get; set; }
        public ICollection<Search> Busquedas { get; set; }
        public ICollection<Lista> Listas { get; set; }

    }
}
