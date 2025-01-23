using System;
using System.Collections.Generic;
using System.Text;
using NewsApp.Languages;

namespace NewsApp.News
{
    public class NewDto
    {
        public string Titular { get; set; }
        public string Cuerpo { get; set; }
        public DateTime Fecha { get; set; }
        public LanguageEnum Idioma { get; set; }
    }
}