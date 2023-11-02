using NewsApp.Alerts;
using NewsApp.BusquedaNoticia;
using NewsApp.Newss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Searches
{
    public class Search : Entity<int>
    {
       // public int SearchId { get; set; }
        public DateTime FechaBusqueda { get; set; }
        public Boolean Resultado { get; set; }
        public string Cadena { get; set; }

       // public List<string> Sugerencias { get; set; }     //ERROR AL MAPEAR
        public Alert Alerta { get; set; }       //COMO ES RELACION UNO A UNO TENGO QUE DEFINIR LOS ID

        public ICollection<SearchNews> BusquedaNoticias { get; set; }

    }
}
