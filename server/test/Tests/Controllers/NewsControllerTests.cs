using Microsoft.AspNetCore.Mvc;
using Moq;
using server.Business.Interfaces;
using server.Controllers;
using server.Models;
using System.Collections.Generic;
using Xunit;

namespace test.Tests.Controllers
{
    public class NewsControllerTests
    {
        private readonly Mock<INewsService> _mock;
        private readonly NewsController _newsController;
        public NewsControllerTests()
        {
            _mock = new Mock<INewsService>();
            _newsController = new NewsController(_mock.Object);
        }

        [Fact]
        public void Should_Return_newss()
        {
            _mock.Setup(item => item.GetAllNews("", "", "")).Returns(It.IsAny<IEnumerable<News>>());
            var actual = (OkObjectResult)_newsController.GetAll("");
            _mock.Verify(item => item.GetAllNews("", "", ""), Times.Once);
            Assert.IsAssignableFrom<IActionResult>(actual);
            Assert.Equal(200, actual.StatusCode);
        }

        [Fact]
        public void Should_Return_Favorite_News()
        {
            _mock.Setup(item => item.GetFavorites()).Returns(It.IsAny<IEnumerable<News>>());
            var actual = (OkObjectResult)_newsController.GetFavorites();
            _mock.Verify(item => item.GetFavorites(), Times.Once);
            Assert.IsAssignableFrom<IActionResult>(actual);
            Assert.Equal(200, actual.StatusCode);
        }

        [Fact]
        public void Add_to_Favorites_Functionality_Should_Work()
        {
            var news = new News
            {
                Title = ""
            };

            _mock.Setup(item => item.AddNews(news));
            var actual = (CreatedResult)_newsController.AddToFavorites(news);
            _mock.Verify(item => item.AddNews(news), Times.Once);
            Assert.IsAssignableFrom<IActionResult>(actual);
            Assert.Equal(201, actual.StatusCode);
        }

        [Fact]
        public void Should_Not_Add_to_Favorites_When_Already_Added()
        {
            var news = new News
            {
                Title = ""
            };

            _mock.Setup(item => item.AlreadyFavorited(news)).Returns(news);
            _mock.Setup(item => item.AddNews(news));
            var actual = (BadRequestObjectResult)_newsController.AddToFavorites(news);
            _mock.Verify(item => item.AlreadyFavorited(news), Times.Once);
            _mock.Verify(item => item.AddNews(news), Times.Never);
            Assert.IsAssignableFrom<IActionResult>(actual);
            Assert.Equal(400, actual.StatusCode);
        }

        [Fact]
        public void Delete_from_Favorites_Functionality_Should_Work()
        {
            var news = new News
            {
                Title = ""
            };

            _mock.Setup(item => item.RemoveFromFavorites(news));
            var actual = (OkObjectResult)_newsController.DeleteFromFavorites(news);
            _mock.Verify(item => item.RemoveFromFavorites(news), Times.Once);
            Assert.IsAssignableFrom<IActionResult>(actual);
            Assert.Equal(200, actual.StatusCode);
        }
    }
}
