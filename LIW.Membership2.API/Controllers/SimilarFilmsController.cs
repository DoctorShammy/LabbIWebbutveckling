using LIW.Common.DTOs;
using LIW.Membership.Database.Enteties;
using LIW.Membership2.API.Util;

namespace LIW.Membership2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SimilarFilmController : ControllerBase
    {
        private readonly IDbService _db;

        public SimilarFilmController(IDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                _db.Include<SimilarFilmscs>();
                List<SimilarFilmsDTO>? similarFilms = await _db.GetAsync<SimilarFilmscs, SimilarFilmsDTO>();
                return Results.Ok(JsonUtility.RemoveLoops(similarFilms));
            }
            catch
            {
                return Results.NotFound();
            }
        }
		//[HttpPut("{id}")]

		//public async Task<IResult> Put(int id, [FromBody] List<SimilarFilmsDTO> dto)
		//{
		//    try
		//    {
		//        if (dto == null)
		//        {
		//            return Results.BadRequest();
		//        }
		//        var toKeep = await _db.GetAsync<SimilarFilmscs, SimilarFilmsDTO>(a => a.FilmId == id && dto.Select(b => b.SimilarFilmId).ToList().Contains(a.SimilarFilmId));
		//        var toDelete = await _db.GetAsync<SimilarFilmscs, SimilarFilmsDTO>(a => a.FilmId == id && !dto.Select(a => a.SimilarFilmId).ToList().Contains(a.SimilarFilmId));
		//        var toAdd = dto.Where(a => !toKeep.Select(b => b.SimilarFilmId).ToList().Contains(a.SimilarFilmId)).ToList();

		//        foreach (var item in toDelete)
		//        {
		//            _db.DeleteAsync<SimilarFilmscs>(new SimilarFilmscs() { FilmId = (int)item.FilmId, SimilarFilmId = (int)item.SimilarFilmId });
		//            await _db.SaveChangesAsync();
		//        }
		//        foreach (var item in toAdd)
		//        {
		//            _db.AddAsync<SimilarFilmscs, SimilarFilmsDTO>(item);
		//        }

		//        var success = await _db.SaveChangesAsync();
		//        if (!success)
		//        {
		//            return Results.BadRequest();
		//        }
		//        return Results.NoContent();
		//    }
		//    catch
		//    {
		//        return Results.BadRequest();
		//    }
		//}
		[HttpPost] 
		public async Task<IResult> Post(SimilarFilmsDTO dto) 
		{ 
			try 
			{ if (dto == null) return Results.BadRequest(); 
				var filmgenre = await _db.AddAsync<SimilarFilmscs, SimilarFilmsDTO>(dto);
				var success = await _db.SaveChangesAsync(); 
				if (!success) return Results.BadRequest(); 
				return Results.Ok(); 
			} 
			catch 
			{ 
			} 
			return Results.NotFound(); 
		}
		[HttpDelete]

		public async Task<IResult> Delete(SimilarFilmsDTO dto)
		{
			try
			{
				_db.Delete<SimilarFilmscs, SimilarFilmsDTO>(dto);
				var success = await _db.SaveChangesAsync(); if (!success) return Results.BadRequest(); return Results.NoContent();
			}
			catch { }
			return Results.BadRequest();
		}

	}
}
