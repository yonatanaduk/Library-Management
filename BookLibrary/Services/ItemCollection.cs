using BookLibrary.Servic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static BookLibrary.Book;
using static BookLibrary.Journal;

namespace BookLibrary
{
    public class ItemCollection : IDataServiceFilter, IDataServicEditItem
    {
        /// <summary>
        /// this class should need to make 2 function / fiilter and edit items.
        /// 
        /// </summary>

        public event Action<List<AbstractItem>> Refresh;
        public event Action MessageBooks;
        public event Action MessageNotFounded;
        public static Hashtable my_hashtable = new Hashtable();
        public static List<AbstractItem> _list = new List<AbstractItem>();

        public List<AbstractItem> FilterFunc(object str, object author, object isbm, object price, bool checkName, bool checkIsbm, bool checkAuthor, bool checkPrice)
        {
            List<AbstractItem> list = new List<AbstractItem>();
            bool checking = true;

            try
            {

                foreach (var item in _list)
                {
                    if (checkName)
                    {
                        string _name = str.ToString();
                        if (!item.Name.ToLower().Contains(_name.ToLower()))
                            checking = false;
                    }
                    if (checkAuthor)
                    {
                        string _author = author.ToString();
                        if (!item.Auther.ToLower().Contains(_author.ToLower()))
                            checking = false;
                    }
                    if (checkIsbm)
                    {
                        string _isbm = isbm.ToString();
                        if (!item.ISBN.ToString().Contains(_isbm.ToString()))
                            checking = false;
                    }
                    if (checkPrice)
                    {
                        string _price = price.ToString();
                        if (!item.Price.ToString().Contains(_price.ToString()))
                            checking = false;
                    }
                    if (checking)
                    {
                        list.Add(item);
                    }
                    checking = true;

                }

            }
            catch (Exception)
            {
                MessageNotFounded?.Invoke();
            }

            Refresh?.Invoke(list);
            return list;

        }
        public bool EditItems(ref AbstractItem item, long isbn, double price, int copis, double discount, int itemStock, bool checkIsbm, bool checkPrice, bool checkCopies, bool checkDiscount, bool checkStock)
        {

            try
            {
                if (checkIsbm) item.ISBN = isbn;
                if (checkPrice) item.Price = price;
                if (checkCopies) item.Copies = copis;
                if (checkDiscount) item.Discount = discount;
                if (checkStock) item.Stock = itemStock;
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
