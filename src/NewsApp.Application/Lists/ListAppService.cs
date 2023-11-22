using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using NewsApp.List;
using NewsApp.Permissions;
using NewsApp.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace NewsApp.Lists
{
    [Authorize]
    public class ListAppService : NewsAppAppService, IListsAppService
    {
        private readonly IRepository<Lista, int> _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ListManager _listManager;

        public ListAppService(IRepository<Lista, int> repository, UserManager<ApplicationUser> userManager, ListManager listManager)
        {
            _repository = repository;
            _userManager = userManager;
            _listManager = listManager;
        }

        public async Task<ICollection<ListsDto>> GetListsAsync()
        {
            var lists = await _repository.GetListAsync(includeDetails: true);

            return ObjectMapper.Map<ICollection<Lista>, ICollection<ListsDto>>(lists);
        }

        public async Task<ListsDto> GetListsAsync(int id)
        {
            var queryable = await _repository.WithDetailsAsync(x => x.ListaNoticias);

            var query = queryable.Where(x => x.Id == id);

            var lista = await AsyncExecuter.FirstOrDefaultAsync(query);

            return ObjectMapper.Map<Lista, ListsDto>(lista);

        }

        public async Task<ListsDto> CreateAsync(CretateListsDto input)
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();

            var applicationUser = await _userManager.FindByIdAsync(userGuid.ToString());

            var lista = await _listManager.CreateAsyncOrUpdate(input.Id, input.Name, input.ListaPadreId, applicationUser);

            if (input.Id is null)
            {
                lista = await _repository.InsertAsync(lista, autoSave: true);
            }
            else
            {
                await _repository.UpdateAsync(lista, autoSave: true);
            }

            return ObjectMapper.Map<Lista, ListsDto>(lista);
        }
    }
}
