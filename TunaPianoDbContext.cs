using Microsoft.EntityFrameworkCore;
using TunaPiano.Models;

public class TunaPianoDbContext : DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Artist>().HasData(
            new { Id = 1, Name = "Yoshiyuki Tomino", Age = 79, Bio = "Creator of the Gundam series." },
            new { Id = 2, Name = "Amuro Ray", Age = 20, Bio = "Protagonist of Mobile Suit Gundam." },
            new { Id = 3, Name = "Char Aznable", Age = 27, Bio = "The Red Comet, rival of Amuro Ray." },
            new { Id = 4, Name = "Heero Yuy", Age = 16, Bio = "Pilot of the Gundam Wing Zero." }
        );

        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Orchestral", Description = "A genre of music that is orchestrated and instrumental." },
            new { Id = 2, Name = "J-Pop", Description = "Popular music from Japan, also known as Japanese pop music." },
            new { Id = 3, Name = "Rock", Description = "A broad genre of popular music that emphasizes electric guitars, drums, and strong vocals." },
            new { Id = 4, Name = "Electronic", Description = "Music that employs electronic musical instruments and technology in its production." }
        );

        modelBuilder.Entity<Song>().HasData(
            new { Id = 1, Title = "Tobe! Gundam", ArtistId = 1, Album = "Mobile Suit Gundam", Length = 240 },
            new { Id = 2, Title = "Invoke", ArtistId = 2, Album = "Gundam SEED", Length = 215 },
            new { Id = 3, Title = "Just Communication", ArtistId = 3, Album = "Gundam Wing", Length = 210 },
            new { Id = 4, Title = "Rhythm Emotion", ArtistId = 4, Album = "Gundam Wing: Endless Waltz", Length = 230 }
        );
    }
}
