using NewsApp.Alerts;
using NewsApp.RelationSearchNews;
using NewsApp.News;
using NewsApp.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace NewsApp.Searches
{
    public class Search : Entity<int>
    {
       // public int SearchId { get; set; }
        public DateTime FechaBusqueda { get; set; }
        public Boolean Resultado { get; set; }
        public string Cadena { get; set; }

       // public List<string> Sugerencias { get; set; }     //ERROR AL MAPEAR

        //Relacion 1 a 0..1 con Alerta
        public Alert Alerta { get; set; }       //COMO ES RELACION UNO A UNO TENGO QUE DEFINIR LOS ID

        //Relacion * a * con Busqueda
        public ICollection<SearchNew> BusquedaNoticias { get; set; }

        //Relacion 1 a * con Usuario
        public Guid UsuarioID { get; set; }
        public ApplicationUser Usuario {  get; set; }
    }
}
