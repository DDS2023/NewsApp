﻿using NewsApp.BusquedaNoticia;
using NewsApp.List;
using NewsApp.News;
using NewsApp.RelationNewThemes;
using NewsApp.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Newss
{
    public class New : Entity<int>
    {
        public string Titular { get; set; }
        public string Cuerpo { get; set; }
        public DateTime Fecha { get; set; }
        public Idiomas Idioma { get; set; }
        public int TemaId { get; set; }
        public Theme Tema { get; set; }

        public  Lista Lista { get; set; }

        public int ListaId { get; set; }
        public ICollection<SearchNews> BusquedaNoticias { get; set; }

     

       // public ICollection<NewThemes> NoticiaTemas { get; set; }


    }
}
