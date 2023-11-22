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
        Task<ICollection<ListsDto>> GetListsAsync();

        Task<ListsDto> GetListsAsync(int id);

        Task<ListsDto> CreateAsync(CretateListsDto input);
    }
}
