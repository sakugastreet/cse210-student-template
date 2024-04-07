using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = Libary; Trusted_Connection = True; TrustServerCertificate=True");
    }
}