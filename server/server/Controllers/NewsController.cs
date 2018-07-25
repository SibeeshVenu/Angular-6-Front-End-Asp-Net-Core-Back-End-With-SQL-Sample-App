using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Business;
using server.Business.Interfaces;
using server.Constants;

namespace server.Controllers
{
    [Produces("application/json"), Route("api/News")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll(string searchType, string q = "", string category = "")
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var news = _newsService.GetAllNews(searchType, q, category);
                return Ok(news);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unable to fetch news this time, please try again later!.");
            }
        }

        [HttpDelete("deleteFromFavorites")]
        public IActionResult DeleteFromFavorites([FromBody] News news)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _newsService.RemoveFromFavorites(news);
                return Ok(news);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unable to delete news from the favorite list this time, please try again later!.");
            }
        }

        [HttpPost("addToFavorites")]
        public IActionResult AddToFavorites([FromBody] News news)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var existingMovie = _newsService.AlreadyFavorited(news);
                if (existingMovie != null)
                    return BadRequest(ApiConstants.newsAlreadyExists);
                _newsService.AddNews(news);
                return Created("api/News/Add", news);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unable to add news to the favorite list this time, please try again later!.");
            }
        }

        [HttpGet("getFavorites")]
        public IActionResult GetFavorites()
        {
            try
            {
                var movies = _newsService.GetFavorites();
                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(500, "Unable to get the favorite news this time, please try again later!.");
            }
        }

    }
}