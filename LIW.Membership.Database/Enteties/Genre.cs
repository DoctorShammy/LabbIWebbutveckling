

namespace LIW.Membership.Database.Enteties
{
	public class Genre : IEntity
	{
		public int Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }

		public virtual ICollection<FilmGenre> FilmGenres { get; set; }
	}
}
