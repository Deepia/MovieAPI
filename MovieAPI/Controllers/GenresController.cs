using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Entities;
using MovieAPI.Filters;
using MovieAPI.Services;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        //private readonly IRepository repository;
        private readonly ILogger<GenresController> logger;
        public GenresController(IRepository reposiory, ILogger<GenresController> logger)
        {
            //this.repository = reposiory;
            this.logger = logger;
        }
        [HttpGet]
        [HttpGet("list")]
        [HttpGet("/allgenres")]
        //[ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("Getting all the genres.");
            return  new List<Genre>(){ new Genre { Id = 1, Name = "Action" } };
        }
        [HttpGet("{Id:int}/{par1=Dee}")]
        public ActionResult<Genre> Get(int Id, string par1)
        {
            //var genre = repository.GetGenreById(Id);
            //if(genre == null)
            //{
            //    logger.LogWarning($"Genre with Id {Id} not found");
            //    throw new ApplicationException();
            //    return NotFound();

            //}
            //return genre;
            throw new NotImplementedException();
        }
        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            
            return NoContent();
        }
        [HttpPut]
        public ActionResult Put()
        {
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
}
