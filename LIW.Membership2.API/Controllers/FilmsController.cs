﻿using LIW.Common.DTOs;
using LIW.Membership.Database.Enteties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Collections.Specialized.BitVector32;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIW.Membership2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {

        private readonly IDbService _db;

        public FilmsController(IDbService db) => _db = db;


        // GET: api/<FilmsController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                _db.Include<Director>();
                //_db.Include<FilmGenre>();

                List<FilmDTO>? film = await _db.GetAsync<Film, FilmDTO>();

                return Results.Ok(film);
            }
            catch (Exception ex)
            {

            }
            return Results.NotFound();

        }

        // GET api/<FilmsController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                _db.Include<Director>();
                //_db.Include<FilmGenre>();
                var film = await _db.SingleAsync<Film, FilmDTO>(c => c.Id.Equals(id));

                return Results.Ok(film);
            }

        catch
            {

            }
            return Results.NotFound();
        }

        // POST api/<FilmsController>
        [HttpPost]
    
        public async Task<IResult> Post([FromBody] FilmCreateDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return Results.BadRequest();
                }
                var film = await _db.AddAsync<Film, FilmCreateDTO>(dto);
                var success = await _db.SaveChangesAsync();
                if (!success)
                {
                    return Results.BadRequest();
                }
                //vad händer här?
                return Results.Ok();
            }
            catch
            {
                return Results.BadRequest();
            }
        }

        // PUT api/<FilmsController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] FilmEditDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return Results.BadRequest();
                }

                if (!id.Equals(dto.Id))
                {
                    return Results.BadRequest();
                }

                var finns = await _db.AnyAsync<Director>(i => i.Id.Equals(dto.DirectorId));
                if (!finns)
                {
                    return Results.NotFound();
                }
                finns = await _db.AnyAsync<Film>(i => i.Id.Equals(id));
                if (!finns)
                {
                    return Results.NotFound();
                }

                _db.Update<Film, FilmEditDTO>(dto.Id, dto);

                var success = await _db.SaveChangesAsync();
                if (!success)
                {
                    return Results.BadRequest();
                }

                return Results.NoContent();
            }
            catch
            {
                return Results.BadRequest();
            }
        }

        // DELETE api/<FilmsController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                var success = await _db.DeleteAsync<Film>(id);
                if (!success)
                {
                    return Results.NotFound();
                }

                success = await _db.SaveChangesAsync();
                if (!success)
                {
                    return Results.BadRequest();
                }
                return Results.NoContent();
            }
            catch
            {
                return Results.BadRequest();
            }
        }

    }
}

