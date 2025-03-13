using BlogApi.DomainLayer.Models;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BlogApi.DataAccessLayer.Data
{
    public class ApplicationDBContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User> Role { get; set; }

    }
}
