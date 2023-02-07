

namespace LIW.Membership.Database.Enteties
{
	public class Film : IEntity
	{

        public Film()
        {
            SimilarFilms = new HashSet<SimilarFilmscs>();
            Genres = new HashSet<Genre>();
        }

        public int Id { get; set; }

		[MaxLength(50),Required]
		public string Title { get; set; }

		public DateTime Released { get; set; }

		public int DirectorId {get; set;}

		public bool Free { get; set; }

		[MaxLength(200)]

		public string Description { get; set; }

		[MaxLength(1024)]

		public string FilmUrl { get; set; }
        public virtual ICollection<SimilarFilmscs> SimilarFilms { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual Director Director { get; set; } = null!;

    }
}
