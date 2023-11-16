using NewsApp.List;
using NewsApp.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace NewsApp.Users
{
    public class ApplicationUser: IdentityUser
    {
        public ICollection<Search> Busquedas { get; set; }
        public ICollection<Lista> Listas { get; set; }

    }
}
