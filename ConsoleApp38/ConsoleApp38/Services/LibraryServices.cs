using ConsoleApp38.Interfaces;
using ConsoleApp38.Models;
using System.Xml.Serialization;

namespace ConsoleApp38.Services;

public class LibraryServices : ILibraryServices
{
    private IGenericServices<Book> bookServices;
    private IGenericServices<Author> authorServices;


    public LibraryServices(string bookUrl, string AuthorUrl)
    {
        bookServices = new GenericService<Book>(bookUrl);
        authorServices = new GenericService<Author>(AuthorUrl);
    }

    public void AddAuthor()
    {
        Console.WriteLine("Shemoikvane Saxeli");
        var Name = Console.ReadLine();
        Console.WriteLine("shemoikvane gvari");
        var Surname = Console.ReadLine();
        Console.WriteLine("Cocxalia? 1:0");
        var IsAlive = Console.ReadLine();
        var alive = false;
        if (IsAlive == "1") alive = true;


        var AllAuthor = authorServices.Getall();
        var maxId = AllAuthor?.Any() == true ? AllAuthor.Max(i => i.Id) : 0;
        var Author = new Author
        {
            Id = maxId + 1,
            IsAlive = alive,
            Name = Name,
            Surname = Surname
        };
        authorServices.Addnew(Author);
    }

    public void AddBook()
    {
        Console.WriteLine("Shemoikvane Saxeli");
        var title = Console.ReadLine();
        Console.WriteLine("shemoikvane description");
        var description = Console.ReadLine();
        
        Console.WriteLine("enter page count");
        if (!int.TryParse(Console.ReadLine(), out var PageCount) || PageCount <= 0)
        {
            Console.WriteLine("Invalid page count");
            return;
        }
        
        Console.WriteLine("enter book count");
        if (!int.TryParse(Console.ReadLine(), out var BookCount) || BookCount <= 0)
        {
            Console.WriteLine("Invalid book count");
            return;
        }
        
        Console.WriteLine("Is Best Seler? Yes-1 no-else");
        var IsBestSale = Console.ReadLine() == "1";

        Console.WriteLine("Enter Author Id:");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Invalid author ID");
            return;
        }
        
        var AllAuth = authorServices.Getall();
        var author = AllAuth?.FirstOrDefault(i => i.Id == id);

        if (author == null)
        {
            Console.WriteLine("Author not found");
            return;
        }
        
        if (author.Books.Any(i => i.Tittle == title && i.Description == description))
        {
            Console.WriteLine("Msgavsi wigni arsebobs");
            return;
        }
        
        var AllBooks = bookServices.Getall();
        var MaxId = AllBooks?.Any() == true ? AllBooks.Max(i => i.Id) : 0;
        
        var book = new Book
        {
            Id = MaxId + 1,
            Description = description,
            Author = author,
            Count = BookCount,
            IsBestSeller = IsBestSale,
            Pages = PageCount,
            Tittle = title
        };
        
        bookServices.Addnew(book);
        author.Books.Add(book);
        authorServices.UpdateAt(author.Id, author);
        
        Console.WriteLine("wigni warmatebit daemata");
    }

    public void GetAllAuthors()
    {
        var authors = authorServices.Getall();
        foreach (var author in authors)
        {
            Console.WriteLine(author);
        }
    }

    public void Search()
    {
        Console.WriteLine("Shemoikvanet sadziebo sitkva");
        var keyword = Console.ReadLine();

        var authors = authorServices.Getall();

        var fillterauthors = authors.Where(i => i.Name.Contains(keyword) || i.Surname.Contains(keyword));
        foreach (var author in fillterauthors)
        {
            Console.WriteLine(author);
        }
    }

    public void GetAllBooks()
    {
        var books = bookServices.Getall();
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}