using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookLibrary.Book;

namespace BookLibrary
{
    public class Journal : AbstractItem
       
    {
        public enum CategoryTypeJournal
        {
            Newspaper = 64,
            magazine = 128,
            Artistic = 256,
            Food = 512,
            Travel = 1024,
        }
        //public CategoryType Category { get; set; }

        public Journal(string name, string author, long isbm, double price, int copies, DateTime date, double disount, int stock , CategoryType category, CategoryTypeJournal categoryJournal) : base(name, author, isbm, price, copies, date, disount, stock , category , categoryJournal)
        {
            Name = name;
            Auther = author;
            ISBN = isbm;
            Price = price;
            Copies = copies;
            DatePrint = date;
            Discount = disount;
            Stock = stock;
            Catgory = 0;
            CatgoryJournal = categoryJournal;
           
        }
    }
}
