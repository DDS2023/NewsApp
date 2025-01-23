using NewsApp.Languages;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using NewsApp.Lists;
using NewsApp.Searches;

namespace NewsApp.Users
{
    public class ApplicationUserDto : EntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public LanguageEnum Idioma { get; set; }
        public ICollection<SearchDto> Busquedas { get; set; }
        public ICollection<ListaDto> Listas { get; set; }
    }
}