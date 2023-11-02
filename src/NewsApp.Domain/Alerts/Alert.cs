using NewsApp.Searches;
using NewsApp.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Alerts
{
    public class Alert : Entity<int>
    {
      //  public int AlertId { get; set; }
      //  public string Descripcion { get; set; }
        public DateTime Hora { get; set; }
        public Boolean Estado { get; set; }
        public Search Busqueda { get; set; }
        public int AlertaBusquedaId { get; set; }

    }
}
