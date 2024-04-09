using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

public class LibraryContext : DbContext
{
    public DbSet<Content> Contents { get; set; }
    public DbSet<DVD> DVDs { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = Test; Trusted_Connection = True; TrustServerCertificate=True");
    }
}