using Microsoft.AspNetCore.Identity;
using NewsApp.List;
using NewsApp.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace NewsApp.Lists
{
    public class ListManager : DomainService
    {
        private readonly IRepository<Lista, int> _repository;
        public ListManager(IRepository<Lista, int> repository)
        {
            
            _repository = repository;
        }

        public async Task<Lista> CreateAsyncOrUpdate(int? id, string name, int? parentId, ApplicationUser applicationUser)
        {
            Lista lista = null;

            if (id is not null)
            {
                // Si el id no es nulo significa que se modifica el tema
                lista = await _repository.GetAsync(id.Value, includeDetails: true);

                lista.Nombre = name;
            }
            else
            {
                //Si el id es nulo, es un tema nuevo
                lista = new Lista { Nombre = name, Usuario = applicationUser};

                if (parentId is not null)
                {
                    // Si el parent id no es nulo, es un tema hijo de un tema padre.
                    var parentList = await _repository.GetAsync(parentId.Value, includeDetails: true);
                    parentList.SubLista.Add(lista);
                }
            };

            return lista;
        }
    }
}