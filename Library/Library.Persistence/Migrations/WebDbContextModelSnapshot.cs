﻿// <auto-generated />
using System;
using Library.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library.Persistence.Migrations
{
    [DbContext(typeof(WebDbContext))]
    partial class WebDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("book_genre", b =>
                {
                    b.Property<int>("book_id")
                        .HasColumnType("integer");

                    b.Property<int>("genre_id")
                        .HasColumnType("integer");

                    b.HasKey("book_id", "genre_id");

                    b.HasIndex("genre_id");

                    b.ToTable("book_genre");
                });

            modelBuilder.Entity("Library.Domain.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("middle_name");

                    b.HasKey("Id");

                    b.ToTable("author", (string)null);
                });

            modelBuilder.Entity("Library.Domain.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("book", (string)null);
                });

            modelBuilder.Entity("Library.Domain.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("genre_name");

                    b.HasKey("Id");

                    b.ToTable("genre", (string)null);
                });

            modelBuilder.Entity("Library.Domain.LibraryCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<bool>("IsReterned")
                        .HasColumnType("boolean")
                        .HasColumnName("isReturned");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer")
                        .HasColumnName("person_id");

                    b.Property<DateTimeOffset?>("ReturnDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("return_date");

                    b.Property<DateTimeOffset>("TakeDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("take_date");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PersonId");

                    b.ToTable("library_card", (string)null);
                });

            modelBuilder.Entity("Library.Domain.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Birthday")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("middle_name");

                    b.HasKey("Id");

                    b.ToTable("person", (string)null);
                });

            modelBuilder.Entity("book_genre", b =>
                {
                    b.HasOne("Library.Domain.Book", null)
                        .WithMany()
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Genre", null)
                        .WithMany()
                        .HasForeignKey("genre_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Domain.Book", b =>
                {
                    b.HasOne("Library.Domain.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Library.Domain.LibraryCard", b =>
                {
                    b.HasOne("Library.Domain.Book", "Book")
                        .WithMany("LibraryCards")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("Library.Domain.Person", "Person")
                        .WithMany("LibraryCards")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Library.Domain.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library.Domain.Book", b =>
                {
                    b.Navigation("LibraryCards");
                });

            modelBuilder.Entity("Library.Domain.Person", b =>
                {
                    b.Navigation("LibraryCards");
                });
#pragma warning restore 612, 618
        }
    }
}
