using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Business.Interfaces
{
    public interface INewsService
    {
        IEnumerable<News> GetAllNews(string searchType, string q, string category);
        void RemoveFromFavorites(News news);
        News AlreadyFavorited(News news);
        void AddNews(News news);
        IEnumerable<News> GetFavorites();
    }
}
