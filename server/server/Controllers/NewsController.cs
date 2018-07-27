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

        /// <summary>
        /// Controller to initialize service
        /// </summary>
        /// <param name="newsService"></param>
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        /// <summary>
        /// Function to get all the news.
        /// </summary>
        /// <param name="searchType"></param>
        /// <param name="q"></param>
        /// <param name="category"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete from the favorites list
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add news to the favorites list
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get favorites news 
        /// </summary>
        /// <returns></returns>
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