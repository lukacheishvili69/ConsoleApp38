namespace ConsoleApp38.Models;

public class Book
{

    public int Id { get; set; }
    public string? Tittle { get; set; }
    public string? Description { get; set; }
    public Author? Author { get; set; }
    public int Pages { get; set; }
    public bool IsBestSeller { get; set; }
    public int Count { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}; Title:{Tittle}; Description:{Description}; Pages:{Pages}; IsBestSeller:{IsBestSeller}; Count:{Count}; Author:{Author}";
    }
}
