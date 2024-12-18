using HNews.API.Models;
using HNews.API.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace HNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly HackerNewsApiService _hackerNewsApiService;

        public StoriesController(HackerNewsApiService hackerNewsApiService)
        {
            _hackerNewsApiService = hackerNewsApiService;
        }

        /// <summary>
        /// Gets the Stories (testing method)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableCors("CorsRules")]
        [Route("api/Stories")]
        public async Task<IActionResult> GetStoriesAsync() // Task<List<int?>?> GetStoriesAsync()
        {
            try
            {
                var topStories = await _hackerNewsApiService.GetStoriesAsync();
                return StatusCode(StatusCodes.Status200OK,topStories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message, ex.StackTrace });
            }
        }

        [HttpGet]
        [EnableCors("CorsRules")]
        [Route("api/BestStoriesDetails")]
        public async Task<IActionResult> BestStoriesDetailsAsync(int n_param, bool countAllCommentsReplies)
        {
            try
            {
                var bestStories = await _hackerNewsApiService.GetBestStoriesAsync(n_param, countAllCommentsReplies);
                return StatusCode(StatusCodes.Status200OK, bestStories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message, ex.StackTrace });
            }
            
        }
    }
}
