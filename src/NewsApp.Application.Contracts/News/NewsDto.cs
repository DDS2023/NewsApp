using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.News
{
    public class NewsDto
    {
        public string Titular { get; set; }
        public string Cuerpo { get; set; }
        public DateTime Fecha { get; set; }
        public Idioma Idioma { get; set; }
    }
}