using TunaPiano.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddNpgsql<TunaPianoDbContext>(builder.Configuration["TunaPianoDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/genres", (TunaPianoDbContext dbContext, Genre genre) =>
{
    dbContext.Genres.Add(genre);
    dbContext.SaveChanges();

    return Results.Created($"/genres/{genre.Id}", genre);
});

app.MapDelete("/genres/{genreId}", (TunaPianoDbContext dbContext, int genreId) =>
{
    var genre = dbContext.Genres.FirstOrDefault(g => g.Id == genreId);
    if (genre == null)
    {
        return Results.NotFound();
    }

    dbContext.Genres.Remove(genre);
    dbContext.SaveChanges();

    return Results.NoContent();
});

app.MapGet("/genres/{genreId}", (TunaPianoDbContext dbContext, int genreId) =>
{
    var genreWithSongs = dbContext.Genres
        .Where(g => g.Id == genreId)
        .Select(g => new
        {
            g.Id,
            g.Name,
            g.Description,
            Songs = g.SongGenres.Select(sg => new
            {
                sg.Song.Id,
                sg.Song.Title,
                sg.Song.ArtistId,
                sg.Song.Album,
                sg.Song.Length
            }).ToList()
        })
        .FirstOrDefault();

    if (genreWithSongs == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(genreWithSongs);
});

app.MapGet("/genres", (TunaPianoDbContext dbContext) =>
{
    var genres = dbContext.Genres
        .Select(g => new
        {
            g.Id,
            g.Description 
        })
        .ToList();

    return Results.Ok(genres);
});



app.MapPost("/songs", (TunaPianoDbContext dbContext, Song song) =>
{
    dbContext.Songs.Add(song);
    dbContext.SaveChanges();
    return Results.Created($"/songs/{song.Id}", song);
});

app.MapDelete("/songs/{songId}", (TunaPianoDbContext dbContext, int songId) =>
{
    var song = dbContext.Songs.FirstOrDefault(s => s.Id == songId);
    if (song == null)
    {
        return Results.NotFound();
    }

    dbContext.Songs.Remove(song);
    dbContext.SaveChanges();

    return Results.NoContent();
});

app.MapGet("/songs/{songId}", (TunaPianoDbContext dbContext, int songId) =>
{
    var songDetails = dbContext.Songs
        .Where(s => s.Id == songId)
        .Select(s => new
        {
            s.Id,
            s.Title,
            Artist = new
            {
                s.Artist.Id,
                s.Artist.Name,
                s.Artist.Age,
                s.Artist.Bio
            },
            s.Album,
            s.Length,
            Genres = s.SongGenres.Select(sg => new
            {
                sg.Genre.Id,
                sg.Genre.Description
            }).ToList()
        })
        .FirstOrDefault();

    if (songDetails == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(songDetails);
});



app.MapPost("/artists", (TunaPianoDbContext dbContext, Artist artist) =>
{
    dbContext.Artists.Add(artist);
    dbContext.SaveChanges();

    return Results.Created($"/artists/{artist.Id}", artist);
});

app.MapDelete("/artists/{artistId}", (TunaPianoDbContext dbContext, int artistId) =>
{
    var artist = dbContext.Artists.FirstOrDefault(a => a.Id == artistId);
    if (artist == null)
    {
        return Results.NotFound();
    }

    dbContext.Artists.Remove(artist);
    dbContext.SaveChanges();

    return Results.NoContent();
});

app.MapGet("/artists/{artistId}", (TunaPianoDbContext dbContext, int artistId) =>
{
    var artist = dbContext.Artists.Where(a => a.Id == artistId)
        .Select(a => new
        {
            a.Id,
            a.Name,
            a.Age,
            a.Bio,
            SongCount = a.Songs.Count,
            Songs = a.Songs.Select(s => new
            {
                s.Id,
                s.Title,
                s.Album,
                s.Length
            }).ToList()
        }).FirstOrDefault();

    if (artist == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(artist);
});

app.MapGet("/artists", (TunaPianoDbContext dbContext) =>
{
    var artists = dbContext.Artists
        .Select(a => new
        {
            a.Id,
            a.Name,
            a.Age,
            a.Bio
        })
        .ToList();

    return Results.Ok(artists);
});





app.Run();




