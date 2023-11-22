using NewsApp.User;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Lists
{
    public class ListsDto : EntityDto<int>
    {
    
        public string Nombre { get; set; }

        //Para representar la lista con sublistas
        public int ListaPadreId { get; set; }
        public ListsDto ListaPadre { get; set; }
        public List<ListsDto> SubLista { get; set; }

        //
       
        public UserDto Usuario { get; set; }
        public ICollection<ListsDto> ListaNoticias { get; set; }
    }
}
