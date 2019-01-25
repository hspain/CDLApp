﻿// <auto-generated />
using System;
using CieDigitalAssessment.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CieDigitalAssessment.API.Migrations
{
    [DbContext(typeof(CDLAppContext))]
    partial class CDLAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CieDigitalAssessment.API.Models.Customer", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("AddressCity")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("AddressState")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("AddressZip")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.CustomerMovieCopy", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CustomerId");

                    b.Property<int>("MovieCopyId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .HasName("fkIdx_69");

                    b.HasIndex("MovieCopyId")
                        .HasName("fkIdx_66");

                    b.ToTable("CustomerMovieCopy");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.Location", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("AddressCity")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("AddressState")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("AddressZip")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoxArtUrl")
                        .IsRequired()
                        .HasColumnName("BoxArtURL")
                        .IsUnicode(false);

                    b.Property<DateTime>("DateMade")
                        .HasColumnType("datetime");

                    b.Property<string>("Director")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.MovieCopy", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<int>("MovieCopyStatus");

                    b.Property<int>("MovieId");

                    b.Property<int>("RentalBoxId");

                    b.HasKey("Id");

                    b.HasIndex("MovieCopyStatus")
                        .HasName("fkIdx_60");

                    b.HasIndex("MovieId")
                        .HasName("fkIdx_53");

                    b.HasIndex("RentalBoxId")
                        .HasName("fkIdx_50");

                    b.ToTable("MovieCopy");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.MovieCopyStatus", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("MovieCopyStatus");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.RentalBox", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime");

                    b.Property<int>("LocationId");

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .HasName("fkIdx_42");

                    b.HasIndex("StatusId")
                        .HasName("fkIdx_36");

                    b.ToTable("RentalBox");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.RentalBoxStatus", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("RentalBoxStatus");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.Transaction", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("DateTransacted")
                        .HasColumnType("datetime");

                    b.Property<decimal>("TaxAmount")
                        .HasColumnType("decimal(15, 2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(15, 2)");

                    b.Property<int>("TransactionStatusId");

                    b.Property<int>("TransactionTypeId");

                    b.HasKey("Id");

                    b.HasIndex("TransactionStatusId")
                        .HasName("fkIdx_108");

                    b.HasIndex("TransactionTypeId")
                        .HasName("fkIdx_115");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.TransactionMovieCopy", b =>
                {
                    b.Property<int>("Id");

                    b.Property<decimal>("MovieAmount")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("MovieCopyId");

                    b.Property<decimal>("TaxAmount")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.HasIndex("MovieCopyId")
                        .HasName("fkIdx_93");

                    b.HasIndex("TransactionId")
                        .HasName("fkIdx_99");

                    b.ToTable("TransactionMovieCopy");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.TransactionStatus", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("TransactionStatus");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.TransactionType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("TransactionType");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.User", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateLoggedIn")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("StripeToken")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Token");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .HasName("fkIdx_81");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.CustomerMovieCopy", b =>
                {
                    b.HasOne("CieDigitalAssessment.API.Models.Customer", "Customer")
                        .WithMany("CustomerMovieCopy")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_69");

                    b.HasOne("CieDigitalAssessment.API.Models.MovieCopy", "MovieCopy")
                        .WithMany("CustomerMovieCopy")
                        .HasForeignKey("MovieCopyId")
                        .HasConstraintName("FK_66");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.MovieCopy", b =>
                {
                    b.HasOne("CieDigitalAssessment.API.Models.MovieCopyStatus", "MovieCopyStatusNavigation")
                        .WithMany("MovieCopy")
                        .HasForeignKey("MovieCopyStatus")
                        .HasConstraintName("FK_60");

                    b.HasOne("CieDigitalAssessment.API.Models.Movie", "Movie")
                        .WithMany("MovieCopy")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_53");

                    b.HasOne("CieDigitalAssessment.API.Models.RentalBox", "RentalBox")
                        .WithMany("MovieCopy")
                        .HasForeignKey("RentalBoxId")
                        .HasConstraintName("FK_50");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.RentalBox", b =>
                {
                    b.HasOne("CieDigitalAssessment.API.Models.Location", "Location")
                        .WithMany("RentalBox")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_42");

                    b.HasOne("CieDigitalAssessment.API.Models.RentalBoxStatus", "Status")
                        .WithMany("RentalBox")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK_36");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.Transaction", b =>
                {
                    b.HasOne("CieDigitalAssessment.API.Models.TransactionStatus", "TransactionStatus")
                        .WithMany("Transaction")
                        .HasForeignKey("TransactionStatusId")
                        .HasConstraintName("FK_108");

                    b.HasOne("CieDigitalAssessment.API.Models.TransactionType", "TransactionType")
                        .WithMany("Transaction")
                        .HasForeignKey("TransactionTypeId")
                        .HasConstraintName("FK_115");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.TransactionMovieCopy", b =>
                {
                    b.HasOne("CieDigitalAssessment.API.Models.MovieCopy", "MovieCopy")
                        .WithMany("TransactionMovieCopy")
                        .HasForeignKey("MovieCopyId")
                        .HasConstraintName("FK_93");

                    b.HasOne("CieDigitalAssessment.API.Models.Transaction", "Transaction")
                        .WithMany("TransactionMovieCopy")
                        .HasForeignKey("TransactionId")
                        .HasConstraintName("FK_99");
                });

            modelBuilder.Entity("CieDigitalAssessment.API.Models.User", b =>
                {
                    b.HasOne("CieDigitalAssessment.API.Models.Customer", "Customer")
                        .WithMany("User")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_81");
                });
#pragma warning restore 612, 618
        }
    }
}