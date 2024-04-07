using System;
using Microsoft.SqlServer;


//Notes: We need a lot of things. next step might be to create the user Database, maybe as well as the library catalog.
//       Start back by working on the login just below.
class Program
{
    static void Main(string[] args)
    {

        LibraryUI libraryUI = new LibraryUI();
        libraryUI.Main();
        
        // Console.WriteLine("Hello FinalProject World!");
        // using (var context = new LibraryContext())
        // {
        //     context.Database.EnsureCreated();

        //     // Add sample data
        //     context.Books.Add(new Book { Title = "Sample Book 1", Author = "Author 1", Year = 2022 });
        //     Book book = new Book { Title = "Sample Book 2", Author = "Author 2", Year = 2023 };
        //     context.Books.Add(book);
        //     context.Books.Add(new Book { Title = "Sample Book 3", Author = "Author 3", Year = 2023 });

        //     context.Books.Remove(book);
        //     // var allBooks = context.Books.ToList();
        //     // context.Books.RemoveRange(allBooks);

        //     // Save changes to the database
        //     context.SaveChanges();

        //     Console.WriteLine("Sample database created successfully.");
        // }
    }
}