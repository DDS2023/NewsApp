using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace NewsApp.Lists
{
    public interface IListsAppService : IApplicationService
    {
        Task<ICollection<ListaDto>> GetListsAsync();

        Task<ListaDto> GetListsAsync(int id);

        Task<ListaDto> CreateAsync(CretateListsDto input);
    }
}
