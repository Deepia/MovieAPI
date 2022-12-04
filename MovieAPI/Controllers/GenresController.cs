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
        [HttpGet("{Id:int}", Name ="getGenre")]
        public async Task<ActionResult<GenreDTO>> Get(int Id)
        {
            var genre = await dBContext.Genres.FirstOrDefaultAsync(x=>x.Id == Id);
            if(genre == null)
            {
                return NotFound();
            }
            return mapper.Map<GenreDTO>(genre);
            
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
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,[FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre= mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;
            dBContext.Entry(genre).State= EntityState.Modified;
            await dBContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genres = await dBContext.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if(genres == null)
            {
                return NotFound();
            }
            dBContext.Remove(genres);
            await dBContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
