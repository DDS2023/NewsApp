using NewsApp.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Lists
{
    public class ListaDto : EntityDto<int>
    {
        public string Nombre { get; set; }

        //Para representar la lista con sublistas
        public int ListaPadreId { get; set; }
        public ListaDto ListaPadre { get; set; }
        public List<ListaDto> SubLista { get; set; }

        //
        public ApplicationUserDto Usuario { get; set; }
        public ICollection<ListaDto> ListaNoticias { get; set; }
    }
}
