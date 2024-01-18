using System;
using System.Collections.Generic;
using LibrarieModele;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Repository_CodeFirst;

public class ForumContext : DbContext
{
  public ForumContext() { }

  public ForumContext(DbContextOptions<ForumContext> options)
      : base(options) { }

  public override int SaveChanges()
  {
    foreach (var entry in ChangeTracker.Entries<User>().Where(e => e.State == EntityState.Deleted))
    {
      entry.State = EntityState.Modified;
      entry.Entity.IsDeleted = true;
    }
    return base.SaveChanges();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    modelBuilder.Entity<User>()
     .Property(u => u.IsDeleted)
     .HasDefaultValue(false);

    modelBuilder.Entity<User>()
      .HasQueryFilter(u => !u.IsDeleted);




    modelBuilder
        .Entity<Topic>()
        .HasData(
            new Topic { TopicId = 1, TopicName = "News" },
            new Topic { TopicId = 2, TopicName = "Entertainment" }
        );

    modelBuilder
        .Entity<AuthType>()
        .HasData(
            new AuthType
            {
              AuthTypeId = 1,
              AuthTypeName = "Guest",
              Limitation = 1
            },
            new AuthType
            {
              AuthTypeId = 2,
              AuthTypeName = "Registered",
              Limitation = 3
            },
            new AuthType
            {
              AuthTypeId = 3,
              AuthTypeName = "EmailVerified",
              Limitation = 5
            }
        );
    modelBuilder
        .Entity<Role>()
        .HasData(
            new Role { RoleId = 1, RoleName = "User" },
            new Role { RoleId = 2, RoleName = "Admin" }
        );

    modelBuilder
        .Entity<User>()
        .HasData(
            new User
            {
              UserId = 1,
              UserName = "User1",
              AuthTypeId = 2,
              RoleId = 1,
              Email = "user1@gmail.com",
              ImageLink = "some image",
              PasswordHash = "hash"
            },
            new User
            {
              UserId = 2,
              UserName = "User2",
              AuthTypeId = 2,
              RoleId = 1,
              Email = "user2@gmail.com",
              ImageLink = "some image",
              PasswordHash = "hash"
            }
        );

    modelBuilder
        .Entity<Post>()
        .HasData(
            new Post
            {
              PostId = 1,
              Heading = "Heading1",
              PostText = "Content1",
              PostDate = DateOnly.Parse("2023-11-15"),
              TopicId = 1,
              UserId = 1
            },
            new Post
            {
              PostId = 2,
              Heading = "Heading2",
              PostText = "Content2",
              PostDate = DateOnly.Parse("2023-11-15"),
              TopicId = 2,
              UserId = 2
            }
        );
  }

  public virtual DbSet<AuthType> AuthTypes { get; set; }

  public virtual DbSet<Post> Posts { get; set; }

  public virtual DbSet<PostImage> PostImages { get; set; }

  public virtual DbSet<Role> Roles { get; set; }

  public virtual DbSet<Topic> Topics { get; set; }

  public virtual DbSet<User> Users { get; set; }
}
