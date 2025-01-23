using NewsApp.News;
using NewsApp.Themes;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.RelationNewThemes
{
    public class NewThemeDto : EntityDto<int>
    {
        public int TemaId { get; set; }
        public ThemeDTO Tema { get; set; }
        public int NoticiaId { get; set; }
        public NewDto Noticia { get; set; }
    }
}
