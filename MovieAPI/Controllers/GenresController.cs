using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.DTOs;
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
        private readonly ApplicationDBContext dBContext;
        private readonly IMapper mapper;

        public GenresController(ILogger<GenresController> logger,ApplicationDBContext dBContext,
            IMapper mapper)
        {
            //this.repository = reposiory;
            this.logger = logger;
            this.dBContext = dBContext;
            this.mapper = mapper;
        }
        [HttpGet]
        [HttpGet("list")]
        [HttpGet("/allgenres")]
        //[ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            logger.LogInformation("Getting all the genres.");
            var genres= await dBContext.Genres.ToListAsync();
            return mapper.Map<List<GenreDTO>>(genres);
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
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre=mapper.Map<Genre>(genreCreationDTO);
            dBContext.Add(genre);
            await dBContext.SaveChangesAsync();
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
