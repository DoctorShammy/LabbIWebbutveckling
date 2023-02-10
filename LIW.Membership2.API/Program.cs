//using AutoMapper;
//using LIW.Common.DTOs;
//using LIW.Membership.Database;
//using LIW.Membership.Database.Enteties;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//ConfigureAutoMapper();
//ConfigureServices();
//var app = builder.Build();

//ConfigureMiddleware();

//void ConfigureMiddleware()
//{

//    if (app.Environment.IsDevelopment())
//    {
//        app.UseSwagger();
//        app.UseSwaggerUI();
//    }

//    app.UseHttpsRedirection();

//    app.UseCors("CorsAllAccessPolicy");

//    app.UseAuthorization();

//    app.MapControllers();

//    app.Run();
//}
//void ConfigureServices()
//{
//    builder.Services.AddControllers();
//    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//    builder.Services.AddEndpointsApiExplorer();
//    builder.Services.AddSwaggerGen();

//    builder.Services.AddCors(policy =>
//    {
//        policy.AddPolicy("CorsAllAccessPolicy", opt =>
//            opt.AllowAnyOrigin()
//               .AllowAnyHeader()
//               .AllowAnyMethod()
//        );
//    });

//    builder.Services.AddDbContext<LIWContext>(
//    options => options.UseSqlServer(
//     builder.Configuration.GetConnectionString("LIWConnection")));

//    builder.Services.AddScoped<IDbService, DbService>();
//}

//void ConfigureAutoMapper()
//{
//    var config = new MapperConfiguration(cfg =>
//    {
//            cfg.CreateMap<Director, DirectorDTO>().ReverseMap();
//            cfg.CreateMap<Film, FilmDTO>().ReverseMap();
//            cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();
//            cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
//            cfg.CreateMap<SimilarFilmscs, SimilarFilmsDTO>().ReverseMap();
//            //cfg.CreateMap<FilmCreateDTO, Film>();
//            //cfg.CreateMap<FilmEditDTO, Film>();

///*        var mapper = config.CreateMapper();
//        builder.Services.AddSingleton(mapper);
//*/
//        //cfg.CreateMap<VideoEditDTO, Video>();
//        //cfg.CreateMap<VideoCreateDTO, Video>();

//        //cfg.CreateMap<SectionEditDTO, Section>();
//        //cfg.CreateMap<SectionCreateDTO, Section>();


//    });
//    var mapper = config.CreateMapper();
//    builder.Services.AddSingleton(mapper);
//}

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

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseWebAssemblyDebugging();
//}
//else
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/admin"), app1 =>
//{
//    app1.UseBlazorFrameworkFiles("/admin");
//    app1.UseRouting();
//    app1.UseEndpoints(endpoints =>
//    {
//        endpoints.MapFallbackToFile("/admin/{*path:nonfile}", "/admin/index.html");
//    });
//});

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

        //Director mapping
        cfg.CreateMap<Director, DirectorDTO>()
        .ReverseMap();


        cfg.CreateMap<Genre, GenreDTO>().ReverseMap();



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

        //Genre
        cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();

        //SimilarFilms

        cfg.CreateMap<SimilarFilmscs, SimilarFilmsDTO>().ReverseMap();

    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}
