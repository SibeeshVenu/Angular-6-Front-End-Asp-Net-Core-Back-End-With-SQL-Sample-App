using Moq;
using server.Business;
using server.Business.Interfaces;
using server.Models;
using server.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace test.Tests.Services
{
    public class NewsServiceTests
    {
        private readonly Mock<IUnitOfWork> _mock;
        private readonly INewsService _newsService;

        public NewsServiceTests()
        {
            _mock = new Mock<IUnitOfWork>();
            _newsService = new NewsService(_mock.Object);
        }

        [Fact]
        public void GetAllNews_Return_Correctly()
        {
            _mock.Setup(item => item.News.GetAllNewsFromNewsDb("","","")).Returns(It.IsAny<string>());
            var actual = _newsService.GetAllNews("","","");
            Assert.NotNull(actual);
        }

        [Fact]
        public void GetNews_UnitOfService_GetAll_Called_Correctly()
        {
            _mock.Setup(item => item.News.GetAllNewsFromNewsDb("","","")).Returns(It.IsAny<string>());
            _newsService.GetAllNews("","","");
            _mock.Verify(item => item.News.GetAllNewsFromNewsDb("","",""), Times.Once);
        }

        [Fact]
        public void Get_Favorites_Called_Correctly()
        {
            _mock.Setup(item => item.News.GetAll()).Returns(It.IsAny<IEnumerable<News>>());
            _newsService.GetFavorites();
            _mock.Verify(item => item.News.GetAll(), Times.Once);
        }

        [Fact]
        public void Add_Favorites_Should_work()
        {
            var news = new News
            {
                Title = ""
            };

            _mock.Setup(item => item.News.Add(news));
            _newsService.AddNews(news);
            _mock.Verify(item => item.News.Add(news), Times.Once);
        }

        [Fact]
        public void Remove_Favorites_Should_work()
        {
            var news = new News
            {
                Title = ""
            };

            _mock.Setup(item => item.News.Remove(news));
            _newsService.RemoveFromFavorites(news);
            _mock.Verify(item => item.News.Remove(news), Times.Once);
        }
    }
}