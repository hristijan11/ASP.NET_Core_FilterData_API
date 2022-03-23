using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RentMovies.Models;

#nullable disable

namespace RentMovies.Models
{
    public partial class TheMovieAppContext : DbContext
    {
        public TheMovieAppContext()
        {
        }

        public TheMovieAppContext(DbContextOptions<TheMovieAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JsonResults1> JsonResults1s { get; set; }
        public virtual DbSet<MoviesByName> MoviesByNames { get; set; }
        public virtual DbSet<PopularMovie> PopularMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning BTo protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IBUER3U;Database=TheMovieApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JsonResults1>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.ToTable("JsonResults1");

                entity.Property(e => e.OriginalTitle)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MoviesByName>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MoviesByName");

                entity.Property(e => e.Title)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PopularMovie>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.OriginalTitle)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Popularity)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.VoteAverage)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.VoteCount)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


      
    }
}
