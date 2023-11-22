using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsApp.Lists
{
    public class CretateListsDto
    {
        [Required]
        public string Name { get; set; }

        public int? Id { get; set; }

        public int? ListaPadreId { get; set; }
    }
}