

namespace LIW.Membership.Database.Enteties
{
	public class Film : IEntity
	{
		public int Id { get; set; }

		[MaxLength(50)]
		public string Title { get; set; }

		public DateTime Released { get; set; }

		public int DirectorId {get; set;}

		public bool Free { get; set; }

		[MaxLength(200)]

		public string Description { get; set; }

		[MaxLength(1024)]

		public string FilmUrl { get; set; }

		public virtual ICollection<FilmGenre> FilmGenres { get; set; } //En film kan ha flera genre 
		public virtual ICollection<SimilarFilmscs> SimilarFilmscss { get; set; }

	}
}
