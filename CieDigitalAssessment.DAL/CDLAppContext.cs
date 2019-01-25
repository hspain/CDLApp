using System;
using CieDigitalAssessment.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CieDigitalAssessment.DAL
{

    // We have a DbContext here so that we can reference it in the repository interface
    public partial class CDLAppContext : DbContext
    {
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerMovieCopy> CustomerMovieCopy { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieCopy> MovieCopy { get; set; }
        public virtual DbSet<MovieCopyStatus> MovieCopyStatus { get; set; }
        public virtual DbSet<RentalBox> RentalBox { get; set; }
        public virtual DbSet<RentalBoxStatus> RentalBoxStatus { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionMovieCopy> TransactionMovieCopy { get; set; }
        public virtual DbSet<TransactionStatus> TransactionStatus { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }
        public virtual DbSet<User> User { get; set; }


        public CDLAppContext(DbContextOptions<CDLAppContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddressCity)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.AddressState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AddressStreet)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.AddressZip)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerMovieCopy>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("fkIdx_69");

                entity.HasIndex(e => e.MovieCopyId)
                    .HasName("fkIdx_66");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerMovieCopy)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_69");

                entity.HasOne(d => d.MovieCopy)
                    .WithMany(p => p.CustomerMovieCopy)
                    .HasForeignKey(d => d.MovieCopyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_66");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddressCity)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.AddressName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.AddressState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AddressStreet)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.AddressZip)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.BoxArtUrl)
                    .IsRequired()
                    .HasColumnName("BoxArtURL")
                    .IsUnicode(false);

                entity.Property(e => e.DateMade).HasColumnType("datetime");

                entity.Property(e => e.Director)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovieCopy>(entity =>
            {
                entity.HasIndex(e => e.MovieCopyStatus)
                    .HasName("fkIdx_60");

                entity.HasIndex(e => e.MovieId)
                    .HasName("fkIdx_53");

                entity.HasIndex(e => e.RentalBoxId)
                    .HasName("fkIdx_50");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.MovieCopyStatusNavigation)
                    .WithMany(p => p.MovieCopy)
                    .HasForeignKey(d => d.MovieCopyStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_60");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieCopy)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_53");

                entity.HasOne(d => d.RentalBox)
                    .WithMany(p => p.MovieCopy)
                    .HasForeignKey(d => d.RentalBoxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_50");
            });

            modelBuilder.Entity<MovieCopyStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RentalBox>(entity =>
            {
                entity.HasIndex(e => e.LocationId)
                    .HasName("fkIdx_42");

                entity.HasIndex(e => e.StatusId)
                    .HasName("fkIdx_36");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.RentalBox)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_42");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.RentalBox)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_36");
            });

            modelBuilder.Entity<RentalBoxStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasIndex(e => e.TransactionStatusId)
                    .HasName("fkIdx_108");

                entity.HasIndex(e => e.TransactionTypeId)
                    .HasName("fkIdx_115");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateTransacted).HasColumnType("datetime");

                entity.Property(e => e.TaxAmount).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.TransactionStatus)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.TransactionStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_108");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_115");
            });

            modelBuilder.Entity<TransactionMovieCopy>(entity =>
            {
                entity.HasIndex(e => e.MovieCopyId)
                    .HasName("fkIdx_93");

                entity.HasIndex(e => e.TransactionId)
                    .HasName("fkIdx_99");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MovieAmount).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.TaxAmount).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.MovieCopy)
                    .WithMany(p => p.TransactionMovieCopy)
                    .HasForeignKey(d => d.MovieCopyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_93");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TransactionMovieCopy)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_99");
            });

            modelBuilder.Entity<TransactionStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("fkIdx_81");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateLoggedIn).HasColumnType("datetime");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.StripeToken)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_81");
            });
        }
    }
}
