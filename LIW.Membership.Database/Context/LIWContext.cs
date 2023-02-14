
using LIW.Membership.Database.Enteties;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.WebRequestMethods;

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


                modelBuilder.Entity<Director>().HasData(
                    new { Id = 1, Name = "Peter Jackson" },
                    new { Id = 2, Name = "The Wachowski Sisters" },
                    new { Id = 3, Name = "David Fincher" });
                modelBuilder.Entity<Film>().HasData(
                    new { Id = 1, Title = "The Lord of the Rings: The Fellowship of the Ring", DirectorId = 1, Description = "Hobbits", FilmUrl = "https://www.youtube.com/watch?v=V75dMMIW2B4&t=2s" },
                    new { Id = 2, Title = "Matrix", DirectorId = 2, Description = "Mr Anderson", FilmUrl = "https://www.youtube.com/watch?v=vKQi3bBA1y8" },
                    new { Id = 3, Title = "Fight Club", DirectorId = 3, Description = "First rule of Fight Club", FilmUrl = "https://www.youtube.com/watch?v=O1nDozs-LxI"});


                modelBuilder.Entity<SimilarFilmscs>().HasData(
                    new SimilarFilmscs { FilmId = 2, SimilarFilmId = 1 },
                    new SimilarFilmscs { FilmId = 3, SimilarFilmId = 1 });

                modelBuilder.Entity<Genre>().HasData(
                    new { Id = 1, Name = "Action" },
                    new { Id = 2, Name = "Sci-Fi" },
                    new { Id = 3, Name = "Fantasy" });

                modelBuilder.Entity<FilmGenre>().HasData(
                    new FilmGenre { FilmId = 1, GenreId = 3 },
                    new FilmGenre { FilmId = 2, GenreId = 2 },
                    new FilmGenre { FilmId = 2, GenreId = 1 },
                    new FilmGenre { FilmId = 3, GenreId = 1 });

                
            });

           
        }
    }

}
