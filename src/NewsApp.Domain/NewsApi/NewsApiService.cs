using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsApp.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Users;
using static OpenIddict.Abstractions.OpenIddictConstants;
using Statuses = NewsAPI.Constants.Statuses;


namespace NewsApp.NewsApi
{
    public class NewsApiService: INewsService
    {
        //public async Task<ICollection<NewDto>> GetNewsAsync(string query, ApplicationUser usuario)

        public async Task<ICollection<NewDto>> GetNewsAsync(string query)
        {
            ICollection<NewDto> responseList = new List<NewDto>();            

            // init with your API key
            var newsApiClient = new NewsApiClient("264d2ab426e84225813a7e70fe615677");
            var articlesResponse = await newsApiClient.GetEverythingAsync(new EverythingRequest
            {
                Q = query,
                SortBy = SortBys.Popularity,
                Language = NewsAPI.Constants.Languages.EN,
                
                //Language = (NewsAPI.Constants.Languages?)usuario.Idioma,


                // consultamos de un mes para atras ya que es lo que permite la api gratis
                From = DateTime.Now.AddMonths(-1)
            });

            //TODO: se deberia lanzar una excepcion si la consulta a la api da error.
            if (articlesResponse.Status == Statuses.Ok)
            {
                articlesResponse.Articles.ForEach(t => responseList.Add(new NewDto
                {
                    Author = t.Author,
                    Title = t.Title,
                    Description = t.Description,
                    Url = t.Url,
                    PublishedAt = t.PublishedAt
                }));
            }

            return responseList;
        }

    }
}
