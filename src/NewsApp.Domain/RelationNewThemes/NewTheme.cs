using NewsApp.News;
using NewsApp.Searches;
using NewsApp.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// POR AHORA NO SE USA
namespace NewsApp.RelationNewThemes
{
    public class NewTheme
    {
        public int TemaId { get; set; }
        public Theme Tema { get; set; }

        public int NoticiaId { get; set; }
        public New Noticia { get; set; }
    }
}
