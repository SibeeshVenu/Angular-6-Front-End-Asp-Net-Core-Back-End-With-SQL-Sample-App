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
        /// <summary>
        /// Initialize unit of work
        /// </summary>
        /// <param name="unit"></param>
        public NewsService(IUnitOfWork unit) => _unitOfWork = unit;

        private IUnitOfWork _unitOfWork { get; }

        /// <summary>
        /// Get all news
        /// </summary>
        /// <param name="searchType"></param>
        /// <param name="q"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public IEnumerable<News> GetAllNews(string searchType, string q, string category) => MapNews(_unitOfWork.News.GetAllNewsFromNewsDb(searchType, q, category), searchType);

        /// <summary>
        /// Map news to the News model
        /// </summary>
        /// <param name="data"></param>
        /// <param name="searchType"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        private IEnumerable<News> MapNews(string data, string searchType = "", string category = "")
        {
            if (searchType != "sources")
            {
                searchType = "articles";
            }
            var lstNews = new List<News>();
            if (string.IsNullOrWhiteSpace(data)) return lstNews;
            var newsData = JObject.Parse(data)[searchType];
            lstNews = MapNewsFavoritedNewsId(JsonConvert.DeserializeObject<List<News>>(newsData.ToString()));
            return lstNews;
        }

        /// <summary>
        /// To map the newsid from favorited list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<News> MapNewsFavoritedNewsId(List<News> list)
        {
            foreach (var item in list)
            {
                var favorited = AlreadyFavorited(item);
                if (favorited != null)
                {
                    item.NewsId = favorited.NewsId;
                }
            }
            return list;
        }

        /// <summary>
        /// Remove news form the favorites list
        /// </summary>
        /// <param name="news"></param>
        public void RemoveFromFavorites(News news)
        {
            _unitOfWork.News.Remove(news);
            _unitOfWork.Complete();
        }
        
        /// <summary>
        /// Check whether the news is already favotited or not
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public News AlreadyFavorited(News news) => _unitOfWork.News.SingleOrDefault(m => m.Title == news.Title);

        /// <summary>
        /// Get favorites news
        /// </summary>
        /// <returns></returns>
        public IEnumerable<News> GetFavorites() => _unitOfWork.News.GetAll();

        /// <summary>
        /// Add news
        /// </summary>
        /// <param name="news"></param>
        public void AddNews(News news)
        {
            _unitOfWork.News.Add(news);
            _unitOfWork.Complete();
        }
    }
}
