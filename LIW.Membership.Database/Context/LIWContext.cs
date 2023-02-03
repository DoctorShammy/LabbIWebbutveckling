using LIW.Membership.Database.Enteties;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace LIW.Membership.Database
{
	public class LIWContext : DbContext
	{
		public DbSet<Film> Films => Set<Film>();
		public DbSet<FilmGenre> FilmGenres => Set<FilmGenre>();

		public DbSet<Genre> Genres => Set<Genre>();

		public DbSet<SimilarFilmscs> SimilarFilms => Set<SimilarFilmscs>();

		public DbSet<Director> Directors => Set<Director>();

		public LIWContext(DbContextOptions<LIWContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

            builder.Entity<FilmGenre>().HasKey(fg => new { fg.FilmId, fg.GenreId });
            builder.Entity<SimilarFilmscs>().HasKey(fg => new { fg.ParentFilmId, fg.SimilarFilmId });


            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}
		}

	}
}
