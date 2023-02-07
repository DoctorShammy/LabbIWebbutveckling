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
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //	//base.OnModelCreating(builder);

        //	builder.Entity<FilmGenre>().HasKey(fg => new { fg.FilmId, fg.GenreId });

        //	builder.Entity<SimilarFilmscs>().HasKey(fg => new { fg.FilmId, fg.SimilarFilmId });


        //	builder.Entity<Film>(entity =>
        //	{
        //		entity.HasMany(d => d.SimilarFilms)
        //		.WithOne(p => p.Film)
        //		.HasForeignKey(d => d.Film.Id)
        //		.OnDelete(DeleteBehavior.ClientSetNull);


        //	});

        //	foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        //	{
        //		relationship.DeleteBehavior = DeleteBehavior.Restrict;
        //	}
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Composit Keys */
            modelBuilder.Entity<SimilarFilmscs>().HasKey(ci => new { ci.FilmId, ci.SimilarFilmId });
            modelBuilder.Entity<FilmGenre>().HasKey(ci => new { ci.FilmId, ci.GenreId });

            /* Configuring related tables for the Film table*/
            modelBuilder.Entity<Film>(entity =>
            {
                entity
                    // For each film in the Film Entity,
                    // reference relatred films in the SimilarFilms entity
                    // with the ICollection<SimilarFilms>
                    .HasMany(d => d.SimilarFilms)
                    .WithOne(p => p.Film)
                    .HasForeignKey(d => d.FilmId)
                    // To prevent cycles or multiple cascade paths.
                    // Neded when seeding similar films data.
                    .OnDelete(DeleteBehavior.ClientSetNull);

                // Configure a many-to-many realtionship between genres
                // and films using the FilmGenre connection entity.
                entity.HasMany(d => d.Genres)
                      .WithMany(p => p.Films)
                      .UsingEntity<FilmGenre>()
                      // Specify the table name for the connection table
                      // to avoid duplicate tables (FilmGenre and FilmGenres)
                      // in the database.
                      .ToTable("FilmGenres");
            });

           
        }
    }

}
