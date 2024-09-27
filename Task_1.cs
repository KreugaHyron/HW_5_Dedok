using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_Dedok
{
    class Book
    {
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
    public Book(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Title}, {Author}, {Genre}, {Year}";
    }
}
class BookInventory
{
    private LinkedList<Book> books = new LinkedList<Book>();
    public void AddBook(Book book)
    {
        books.AddLast(book);
    }
    public bool RemoveBook(Book book)
    {
        return books.Remove(book);
    }
    public void UpdateBook(Book oldBook, Book newBook)
    {
        var node = books.Find(oldBook);
        if (node != null)
        {
            node.Value = newBook;
        }
    }
    public IEnumerable<Book> SearchBooks(string title = null, string author = null, string genre = null, int? year = null)
    {
        foreach (var book in books)
        {
            if ((title == null || book.Title == title) &&
                (author == null || book.Author == author) &&
                (genre == null || book.Genre == genre) &&
                (year == null || book.Year == year))
            {
                yield return book;
            }
        }
    }
    public void InsertAtBeginning(Book book)
    {
        books.AddFirst(book);
    }
    public void InsertAtEnd(Book book)
    {
        books.AddLast(book);
    }
    public void InsertAtPosition(Book book, int position)
    {
        if (position < 0 || position > books.Count)
            throw new ArgumentOutOfRangeException(nameof(position), "Неправильна позиція!");

        var node = books.First;
        for (int i = 0; i < position; i++)
        {
            node = node?.Next;
        }

        if (node != null)
            books.AddBefore(node, book);
        else
            books.AddLast(book);
    }
    public void RemoveFromBeginning()
    {
        if (books.Count > 0)
        {
            books.RemoveFirst();
        }
    }
    public void RemoveFromEnd()
    {
        if (books.Count > 0)
        {
            books.RemoveLast();
        }
    }
    public void RemoveAtPosition(int position)
    {
        if (position < 0 || position >= books.Count)
            throw new ArgumentOutOfRangeException(nameof(position), "Неправильна позиція!");

        var node = books.First;
        for (int i = 0; i < position; i++)
        {
            node = node?.Next;
        }

        if (node != null)
        {
            books.Remove(node);
        }
    }
    public void PrintBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}
}
