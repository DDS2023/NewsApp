using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using NewsApp.Searches;
using NewsApp.News;

namespace NewsApp.RelationSearchNews
{
    public class SearchNewDto : EntityDto<int>
    {
        public int BusquedaId { get; set; }
        public SearchDto Busqueda { get; set; }
        public int NoticiaId { get; set; }
        public NewDto Noticia { get; set; }
    }
}
