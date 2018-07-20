using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using server.Business.Interfaces;
using server.Models;
using server.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Business
{
    public class NewsService : INewsService
    {

        public NewsService(IUnitOfWork unit) => _unitOfWork = unit;

        private IUnitOfWork _unitOfWork { get; }

        public IEnumerable<News> GetAllNews(string searchType, string q, string category) => MapNews(_unitOfWork.News.GetAllNewsFromNewsDb(searchType, q, category), searchType);

        private IEnumerable<News> MapNews(string data, string searchType = "", string category = "")
        {
            if (searchType != "sources")
            {
                searchType = "articles";
            }
            var lstNews = new List<News>();
            if (string.IsNullOrWhiteSpace(data)) return lstNews;
            var newsData = JObject.Parse(data)[searchType];
            lstNews = JsonConvert.DeserializeObject<List<News>>(newsData.ToString());
            return lstNews;
        }

        public void RemoveFromFavorites(News news)
        {
            _unitOfWork.News.Remove(news);
            _unitOfWork.Complete();
        }
        
        public News AlreadyFavorited(News news) => _unitOfWork.News.SingleOrDefault(m => m.Title == news.Title);

        public IEnumerable<News> GetFavorites() => _unitOfWork.News.GetAll();

        public void AddNews(News news)
        {
            _unitOfWork.News.Add(news);
            _unitOfWork.Complete();
        }
    }
}
