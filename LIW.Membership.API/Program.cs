using AutoMapper;
using LIW.Common.DTOs;
using LIW.Membership.Database;
using LIW.Membership.Database.Enteties;
using LIW.Membership.Database.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Collections.Specialized.BitVector32;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices();
ConfigureAutoMapper();

void ConfigureMiddleware()
{
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("CorsAllAccessPolicy");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

void ConfigureServices()
{
    builder.Services.AddCors(policy =>
    {
        policy.AddPolicy("CorsAllAccessPolicy", opt =>
            opt.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod()
        );
    });

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<LIWContext>(
    options => options.UseSqlServer(
     builder.Configuration.GetConnectionString("LIWConnection")));

    builder.Services.AddScoped<IDbService, DbService>();
}

void ConfigureAutoMapper()
{
    var config = new AutoMapper.MapperConfiguration(cfg =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Director, DirectorDTO>().ReverseMap();
            cfg.CreateMap<Film, FilmDTO>().ReverseMap();
            cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();
            cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
            cfg.CreateMap<SimilarFilmscs, SimilarFilmsDTO>().ReverseMap();
            //cfg.CreateMap<FilmCreateDTO, Film>();
            //cfg.CreateMap<FilmEditDTO, Film>();
        });

        var mapper = config.CreateMapper();
        builder.Services.AddSingleton(mapper);

        //cfg.CreateMap<VideoEditDTO, Video>();
        //cfg.CreateMap<VideoCreateDTO, Video>();

        //cfg.CreateMap<SectionEditDTO, Section>();
        //cfg.CreateMap<SectionCreateDTO, Section>();


    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);

    var app = builder.Build();
}

