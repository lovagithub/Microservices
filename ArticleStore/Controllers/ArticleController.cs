using ArticleStore.Models;
using ArticleStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleStore.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticleController(ArticleRepository _repo) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(ArticleSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (await _repo.ExistsAsync(x => x.ArticleNamber == schema.ArticleNamber))
                return Conflict($"Article with article number {schema.ArticleNamber} alredy exist.");

            Article result = await _repo.AddAsync(schema);
            return Created("", result);
        }
        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            var result = await _repo.GetAsync();
            var articles = result.Select(x => new Article()).ToList();
            return Ok(articles);
        }
    }
}
