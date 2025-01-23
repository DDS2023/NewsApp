using System;
using System.Collections.Generic;
using System.Text;
using NewsApp.Users;
using Volo.Abp.Application.Dtos;
using NewsApp.Alerts;
using NewsApp.RelationSearchNews;

namespace NewsApp.Searches
{
    public class SearchDto : EntityDto<int>
    {
        
       // public int SearchId { get; set; }
        public DateTime FechaBusqueda { get; set; }
        public Boolean Resultado { get; set; }
        public string Cadena { get; set; }

        // public List<string> Sugerencias { get; set; }     //ERROR AL MAPEAR

        //Relacion 1 a 0..1 con Alerta
        public AlertDto Alerta { get; set; }       //COMO ES RELACION UNO A UNO TENGO QUE DEFINIR LOS ID

        //Relacion * a * con Busqueda
        public ICollection<SearchNewDto> BusquedaNoticias { get; set; }

        //Relacion 1 a * con Usuario
        public Guid UsuarioID { get; set; }
        public ApplicationUserDto Usuario { get; set; }
    }
}
