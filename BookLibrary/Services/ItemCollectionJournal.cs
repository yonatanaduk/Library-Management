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
    public class ItemCollectionJournal : IDataServiceJournal
    {
        public event Action<AbstractItem> AddJournalEvent;
        public event Action MessageJournal;
        public event Action MessageInvalidJournal;
        public readonly Hashtable my_hashtable = ItemCollection.my_hashtable;
        public readonly static List<AbstractItem> _list = ItemCollection._list;

        public bool AddJornal(string name, string author, long isbm, double price, int copies, DateTime date, double disount, int stock, CategoryType category, CategoryTypeJournal categoryJournal)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(author) || isbm <= 0 || price <= 0 || copies < 0 || stock < 0 || date > DateTime.Now)
            {
                MessageInvalidJournal?.Invoke();
                return false;
            }

            var journal = new Journal(name, author, isbm, price, copies, date, disount, stock, category, categoryJournal);
            try
            {
                my_hashtable.Add(isbm, journal);
                _list.Add(journal);
                AddJournalEvent?.Invoke(journal);
                return true;
            }
            catch (Exception)
            {
                MessageJournal?.Invoke();
                return false;
            }
        }

    }
}
