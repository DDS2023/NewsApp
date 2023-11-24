using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.NewsApi
{
         public interface INewsService
        {
            Task<ICollection<NewDto>> GetNewsAsync(string query);
        }
}
