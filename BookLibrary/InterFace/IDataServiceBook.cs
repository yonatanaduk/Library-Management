using System;
using static BookLibrary.Book;
using static BookLibrary.Journal;

namespace BookLibrary.Servic
{
    /// <summary>
    /// here we want to create the interface for the class that used here after. 
    /// </summary>
    public interface IDataServiceBook
    {
        event Action<AbstractItem> AddBooksEvent;
        event Action MessageBooks;
        event Action MessageInvalid;


        bool AddBook(string name, string author, long isbm, double price, int copies, DateTime date, double disount, int stock, CategoryType category, CategoryTypeJournal categoryJournal);

    }
}