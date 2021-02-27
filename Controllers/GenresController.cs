using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesAPI.Entities;
using MoviesAPI.Filters;
using MoviesAPI.Services;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.DTOs;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : CustomBaseController
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "getGenres")] // api/genres
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            return await Get<Genre, GenreDTO>();
            /*var genres = await _context.Genres.AsNoTracking().ToListAsync();
            var genresDtOs = _mapper.Map<List<GenreDTO>>(genres);
            var resourceCollection = new ResourceCollection<GenreDTO>(genresDtOs);
          //  resourceCollection.Links.Add(new Link(Url.Action("getGenres"),rel:"self",method:"GET"));
            genresDtOs.ForEach(genre => GenerateALinks(genre));
            return genresDtOs;*/
        }

        private void GenerateALinks(GenreDTO genreDto)
        {
            genreDto.Links.Add(new Link(Url.Link("getGenre", new {Id = genreDto.Id}), "get-genre", method: "GET"));
            genreDto.Links.Add(new Link(Url.Link("putGenre", new {Id = genreDto.Id}), "get-genre", method: "PUT"));
            genreDto.Links.Add(new Link(Url.Link("deleteGenre", new {Id = genreDto.Id}), "get-genre",
                method: "DELETE"));
        }

        [HttpGet("{Id:int}", Name = "getGenre")] // api/genres/example
        public async Task<ActionResult<GenreDTO>> Get(int id)
        {
            /*var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == Id);

            if (genre == null)
            {
                return NotFound();
            }

            var genreDTO = _mapper.Map<GenreDTO>(genre);
            return genreDTO;*/
            return await Get<Genre, GenreDTO>(id);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDto)
        {
            return await Post<GenreCreationDTO, Genre, GenreDTO>(genreCreationDto, "getGenre");
            /*var genre = _mapper.Map<Genre>(genreCreationDto);
            _context.Add(genre);
            await _context.SaveChangesAsync();
            var genreDTO = _mapper.Map<GenreDTO>(genre);
            return new CreatedAtRouteResult("getGenre", new {genreDTO.Id}, genreDTO);*/
        }

        [HttpPut("{id}", Name = "putGenre")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDTO genreCreationDto)
        {
            return await Put<GenreCreationDTO, Genre>(id, genreCreationDto);
            /*var genre = _mapper.Map<Genre>(genreCreationDto);
            genre.Id = id;
            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();*/
        }

        [HttpDelete("{id}", Name = "deleteGenre")]
        public async Task<ActionResult> Delete(int id)
        {
            /*var exist = await _context.Genres.AnyAsync(g => g.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(new Genre() {Id = id});
                await _context.SaveChangesAsync();
                return NoContent();
            }*/
            return await Delete<Genre>(id);
        }
    }
}