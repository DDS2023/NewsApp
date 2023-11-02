using NewsApp.Newss;
using NewsApp.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.BusquedaNoticia
{
    public class SearchNews
    {
        public int BusquedaId { get; set; }
        public Search Busqueda { get; set; }

        public int NoticiaId { get; set; }
        public New Noticia { get; set; }
    }
}
