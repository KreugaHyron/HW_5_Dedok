// See https://aka.ms/new-console-template for more information
using HW_5_Dedok;
//1
Console.WriteLine("Task_1: ");
var inventory = new BookInventory();

var book1 = new Book("Книга 1", "Автор 1", "Жанр 1", 2001);
var book2 = new Book("Книга 2", "Автор 2", "Жанр 2", 2002);
inventory.AddBook(book1);
inventory.AddBook(book2);

inventory.PrintBooks();

var foundBooks = inventory.SearchBooks(author: "Автор 1");
foreach (var book in foundBooks)
{
    Console.WriteLine("Знайдено: " + book);
}

var updatedBook = new Book("Книга 1 (оновлена)", "Автор 1", "Жанр 1", 2020);
inventory.UpdateBook(book1, updatedBook);
inventory.PrintBooks();

var book3 = new Book("Книга 3", "Автор 3", "Жанр 3", 2003);
inventory.InsertAtBeginning(book3);
inventory.PrintBooks();

inventory.RemoveAtPosition(1);
inventory.PrintBooks();
Console.WriteLine();
//2
Console.WriteLine("Task_2: ");
var dictionary = new EnglishFrenchDictionary();

dictionary.AddWord("hello", new List<string> { "bonjour", "salut" });
dictionary.AddWord("goodbye", new List<string> { "au revoir", "adieu" });

dictionary.PrintDictionary();

var translations = dictionary.SearchTranslation("hello");
if (translations != null)
{
    Console.WriteLine($"Переклади для 'hello': {string.Join(", ", translations)}");
}

dictionary.UpdateWord("goodbye", "farewell");
dictionary.PrintDictionary();

dictionary.UpdateTranslation("farewell", "adieu", "à bientôt");
dictionary.PrintDictionary();

dictionary.RemoveTranslation("hello", "salut");
dictionary.PrintDictionary();

dictionary.RemoveWord("farewell");
dictionary.PrintDictionary();