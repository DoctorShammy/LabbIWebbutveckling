// <auto-generated />
using System;
using LIW.Membership.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LIW.Membership.Database.Migrations
{
    [DbContext(typeof(LIWContext))]
    [Migration("20230214100732_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LIW.Membership.Database.Enteties.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Peter Jackson"
                        },
                        new
                        {
                            Id = 2,
                            Name = "The Wachowski Sisters"
                        },
                        new
                        {
                            Id = 3,
                            Name = "David Fincher"
                        });
                });

            modelBuilder.Entity("LIW.Membership.Database.Enteties.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("FilmUrl")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<bool?>("Free")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Released")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Hobbits",
                            DirectorId = 1,
                            FilmUrl = "https://www.youtube.com/watch?v=V75dMMIW2B4&t=2s",
                            Title = "The Lord of the Rings: The Fellowship of the Ring"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Mr Anderson",
                            DirectorId = 2,
                            FilmUrl = "https://www.youtube.com/watch?v=vKQi3bBA1y8",
                            Title = "Matrix"
                        },
                        new
                        {
                            Id = 3,
                            Description = "First rule of Fight Club",
                            DirectorId = 3,
                            FilmUrl = "https://www.youtube.com/watch?v=O1nDozs-LxI",
                            Title = "Fight Club"
                        });
                });

            modelBuilder.Entity("LIW.Membership.Database.Enteties.FilmGenre", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("FilmGenres", (string)null);

                    b.HasData(
                        new
                        {
                            FilmId = 1,
                            GenreId = 3
                        },
                        new
                        {
                            FilmId = 2,
                            GenreId = 2
                        },
                        new
                        {
                            FilmId = 2,
                            GenreId = 1
                        },
                        new
                        {
                            FilmId = 3,
                            GenreId = 1
                        });
                });

            modelBuilder.Entity("LIW.Membership.Database.Enteties.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("LIW.Membership.Database.Enteties.SimilarFilmscs", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("SimilarFilmId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "SimilarFilmId");

                    b.HasIndex("SimilarFilmId");

                    b.ToTable("SimilarFilms");

                    b.HasData(
                        new
                        {
                            FilmId = 2,
                            SimilarFilmId = 1
                        },
                        new
                        {
                            FilmId = 3,
                            SimilarFilmId = 1
                        });
                });

            modelBuilder.Entity("LIW.Membership.Database.Enteties.Film", b =>
                {
                    b.HasOne("LIW.Membership.Database.Enteties.Director", "Director")
                        .WithMany("Films")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("LIW.Membership.Database.Enteties.FilmGenre", b =>
                {
                    b.HasOne("LIW.Membership.Database.Enteties.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIW.Membership.Database.Enteties.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("LIW.Membership.Database.Enteties.SimilarFilmscs", b =>
                {
                    b.HasOne("LIW.Membership.Database.Enteties.Film", "Film")
                        .WithMany("SimilarFilms")
                        .HasForeignKey("FilmId")
                        .IsRequired();

                    b.HasOne("LIW.Membership.Database.Enteties.Film", "Similar")
                        .WithMany()
                        .HasForeignKey("SimilarFilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Similar");
                });

            modelBuilder.Entity("LIW.Membership.Database.Enteties.Director", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("LIW.Membership.Database.Enteties.Film", b =>
                {
                    b.Navigation("SimilarFilms");
                });
#pragma warning restore 612, 618
        }
    }
}
