using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Constants;
using RestSharp;

namespace server.Repositories
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(DbContext context) : base(context)
        {

        }

        public string GetAllNewsFromNewsDb(string searchType, string q, string category)
        {
            var apiUrl = $"{ApiConstants.baseUrl}{searchType}{ApiConstants.apiKey}";
            if (!string.IsNullOrWhiteSpace(q) && q != "undefined")
            {
                apiUrl = $"{ApiConstants.baseUrl}{searchType}{ApiConstants.apiKey}{"&q="}{q}";
            }
            if (!string.IsNullOrWhiteSpace(category) && category != "undefined")
            {
                apiUrl = apiUrl + "&category=" + category;
            }
            var client = new RestClient(apiUrl);
            var request = new RestRequest(Method.GET);
            return client.ExecuteAsync(request).Result;
        }
    }
}
