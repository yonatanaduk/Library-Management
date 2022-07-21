using BookLibrary.Servic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookLibrary.Book;
using static BookLibrary.Journal;

namespace BookLibrary.Services
{
    /// <summary>
    /// this class hold the book item and he fullfill interface of book.
    /// </summary>
    public class ItemCollectionBook : IDataServiceBook
    {
        public event Action<AbstractItem> AddBooksEvent;
        public event Action MessageBooks;
        public event Action MessageInvalid;
        public readonly Hashtable my_hashtable = ItemCollection.my_hashtable;
        public readonly static List<AbstractItem> _list = ItemCollection._list;

        public bool AddBook(string name, string author, long isbm, double price, int copies, DateTime date, double disount, int stock, CategoryType category, CategoryTypeJournal categoryJournal)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(author) || isbm <= 0 || price <= 0 || copies < 0 || stock < 0 || date > DateTime.Now)
            {
                MessageInvalid?.Invoke();
                return false;
            }
            var book = new Book(name, author, isbm, price, copies, date, disount, stock, category, categoryJournal);
            try
            {
                my_hashtable.Add(isbm, book);
                _list.Add(book);
                AddBooksEvent?.Invoke(book);
                return true;
            }
            catch (Exception)
            {
                MessageBooks?.Invoke();
                return false;
            }
        }

    }
}
