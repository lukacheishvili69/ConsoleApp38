using ConsoleApp38.Interfaces;
using ConsoleApp38.Models;
using ConsoleApp38.Services;
using System.Runtime.InteropServices;



ILibraryServices library = new  LibraryServices(@"C:\Users\User\OneDrive\Desktop\New folder (2)\New Text Document.txt", @"C:\Users\User\OneDrive\Desktop\New folder (2)\New Text Document (2).txt");


library.AddBook();
//library.AddAuthor();
//library.GetAllAuthors();
library.GetAllBooks();
