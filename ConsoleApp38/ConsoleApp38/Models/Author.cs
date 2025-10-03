namespace ConsoleApp38.Models;

public  class Author
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public bool IsAlive { get; set; }

    public List<Book>? Books { get; set; }

    public override string ToString()
    {
        return $"Id:{Id}; Name:{Name}; Surname:{Surname}; IsAlive{IsAlive}";
    }



}
