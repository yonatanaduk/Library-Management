using System;
using static BookLibrary.Book;
using static BookLibrary.Journal;

namespace BookLibrary.Servic
{
    public interface IDataServiceJournal
    {
        event Action<AbstractItem> AddJournalEvent;
        event Action MessageJournal;
        event Action MessageInvalidJournal;

        bool AddJornal(string name, string author, long isbm, double price, int copies, DateTime date, double disount, int stock , CategoryType category, CategoryTypeJournal categoryJournal);
    }
}