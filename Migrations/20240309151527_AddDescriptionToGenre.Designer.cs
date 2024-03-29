﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPiano.Migrations
{
    [DbContext(typeof(TunaPianoDbContext))]
    [Migration("20240309151527_AddDescriptionToGenre")]
    partial class AddDescriptionToGenre
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TunaPiano.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 79,
                            Bio = "Creator of the Gundam series.",
                            Name = "Yoshiyuki Tomino"
                        },
                        new
                        {
                            Id = 2,
                            Age = 20,
                            Bio = "Protagonist of Mobile Suit Gundam.",
                            Name = "Amuro Ray"
                        },
                        new
                        {
                            Id = 3,
                            Age = 27,
                            Bio = "The Red Comet, rival of Amuro Ray.",
                            Name = "Char Aznable"
                        },
                        new
                        {
                            Id = 4,
                            Age = 16,
                            Bio = "Pilot of the Gundam Wing Zero.",
                            Name = "Heero Yuy"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Orchestral"
                        },
                        new
                        {
                            Id = 2,
                            Name = "J-Pop"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rock"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Electronic"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "Mobile Suit Gundam",
                            ArtistId = 1,
                            Length = 240,
                            Title = "Tobe! Gundam"
                        },
                        new
                        {
                            Id = 2,
                            Album = "Gundam SEED",
                            ArtistId = 2,
                            Length = 215,
                            Title = "Invoke"
                        },
                        new
                        {
                            Id = 3,
                            Album = "Gundam Wing",
                            ArtistId = 3,
                            Length = 210,
                            Title = "Just Communication"
                        },
                        new
                        {
                            Id = 4,
                            Album = "Gundam Wing: Endless Waltz",
                            ArtistId = 4,
                            Length = 230,
                            Title = "Rhythm Emotion"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.SongGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("SongId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("SongId");

                    b.ToTable("SongGenre");
                });

            modelBuilder.Entity("TunaPiano.Models.Song", b =>
                {
                    b.HasOne("TunaPiano.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("TunaPiano.Models.SongGenre", b =>
                {
                    b.HasOne("TunaPiano.Models.Genre", "Genre")
                        .WithMany("SongGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunaPiano.Models.Song", "Song")
                        .WithMany("SongGenres")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("TunaPiano.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("TunaPiano.Models.Genre", b =>
                {
                    b.Navigation("SongGenres");
                });

            modelBuilder.Entity("TunaPiano.Models.Song", b =>
                {
                    b.Navigation("SongGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
