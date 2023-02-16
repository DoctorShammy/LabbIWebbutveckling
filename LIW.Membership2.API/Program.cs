using LIW.Common.DTOs;
using LIW.Membership.Database.Enteties;
using Microsoft.EntityFrameworkCore;
using LIW.Membership.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LIWContext>(
options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("LIWConnection")));
builder.Services.AddScoped<IDbService, DbService>();

ConfigureAutomapper();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseBlazorFrameworkFiles("");
app.UseStaticFiles();

app.UseRouting();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

void ConfigureAutomapper()
{
    var config = new AutoMapper.MapperConfiguration(cfg =>
    {
        //Films mapping

        cfg.CreateMap<Film, FilmDTO>().ReverseMap()
        .ForMember(dest => dest.Director, src => src.Ignore());

        cfg.CreateMap<FilmEditDTO, Film>()
        .ForMember(dest => dest.Director, src => src.Ignore())
        .ForMember(dest => dest.Genres, src => src.Ignore())
        .ForMember(dest => dest.SimilarFilms, src => src.Ignore());

        cfg.CreateMap<FilmCreateDTO, Film>()
        .ForMember(dest => dest.Director, src => src.Ignore())
        .ForMember(dest => dest.Genres, src => src.Ignore())
        .ForMember(dest => dest.SimilarFilms, src => src.Ignore());

        cfg.CreateMap<Director, DirectorDTO>().ReverseMap();
        cfg.CreateMap<DirectorCreateDTO, Director>().ReverseMap();

        //Genre
        cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenreDTO>();
        cfg.CreateMap<GenreCreateDTO, Genre>();
        //SimilarFilms

        cfg.CreateMap<SimilarFilmscs, SimilarFilmsDTO>().ReverseMap();

    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}
