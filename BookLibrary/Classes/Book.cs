using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookLibrary.Journal;

namespace BookLibrary
{
    public class Book : AbstractItem
    {
        [Flags]
        public enum CategoryType
        {
            Action = 2,
            Romanticism = 4,
            Comedy = 8, 
            Fictional = 16,
            News = 32,
        }
        public CategoryType Category { get; set; }


        public Book(string name, string author, long isbm, double price, int copies, DateTime date, double disount, int stock , CategoryType category , CategoryTypeJournal categoryJournal) : base(name, author, isbm, price, copies, date , disount, stock , category , categoryJournal)
        {

            Name = name;
            Auther = author;
            ISBN = isbm;
            DatePrint = date;
            Copies = copies;
            Price = price;
            Discount = disount;
            Stock = stock;
            Category = category;
            CatgoryJournal = 0;
        }


    }
}
