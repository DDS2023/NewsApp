using NewsApp.Newss;
using NewsApp.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace NewsApp.List
{
    public class Lista : Entity<int>
    {
        public string Nombre { get; set; }

        //Para representar la lista con sublistas
        public int ListaPadreId { get; set; }
        public Lista ListaPadre {  get; set; }
        public List<Lista> SubLista { get; set; }

        //
        public ApplicationUser Usuario { get; set; }

        public ICollection<New> ListaNoticias { get; set; }
    }
}
