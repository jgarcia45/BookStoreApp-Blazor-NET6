using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser> {
    public BookStoreDbContext() {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options) {
    }

    public virtual DbSet<Author> Authors { get; set; } = null!;

    public virtual DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC076BA28C09");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07149E85B1");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA845A6EC3").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole {
                Name = "User",
                NormalizedName = "USER",
                Id = "692d3644-360c-45a4-9332-4a40bcb73dcc"
            },
            new IdentityRole {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "40ea3c8c-f25e-4861-ae90-a1af1e8a18fa"
            });

        var hasher = new PasswordHasher<ApiUser>();

        modelBuilder.Entity<ApiUser>().HasData(
           new ApiUser {
               Id = "45487ca1-e630-4334-8052-caa404e1ac5c",
               Email = "admin@bookstore.com",
               NormalizedEmail = "ADMIN@BOOKSTORE.COM",
               UserName = "admin@bookstore.com",
               NormalizedUserName = "ADMIN@BOOKSTORE.COM",
               FirstName = "System",
               LastName = "Admin",
               PasswordHash = hasher.HashPassword(null, "P@ssword1")

           },
           new ApiUser {
               Id = "f3b3b6ce-6d74-4dce-a2fe-d57fdba157e5",
               Email = "user@bookstore.com",
               NormalizedEmail = "USER@BOOKSTORE.COM",
               UserName = "user@bookstore.com",
               NormalizedUserName = "USER@BOOKSTORE.COM",
               FirstName = "System",
               LastName = "Udmin",
               PasswordHash = hasher.HashPassword(null, "P@ssword1")
           });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> {
                RoleId = "692d3644-360c-45a4-9332-4a40bcb73dcc",
                UserId = "f3b3b6ce-6d74-4dce-a2fe-d57fdba157e5"
            },
            new IdentityUserRole<string> {
                RoleId = "40ea3c8c-f25e-4861-ae90-a1af1e8a18fa",
                UserId = "45487ca1-e630-4334-8052-caa404e1ac5c"
            });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
