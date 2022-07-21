using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookLibrary.Book;
using static BookLibrary.Journal;

namespace BookLibrary
{
    public abstract class AbstractItem
    {
        public string Name { get; set; }
        public string Auther { get; set; }
        public long ISBN { get; set; }
        public DateTime DatePrint { get; set; }
        public int Copies { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Stock { get; set; }
        public CategoryType Catgory { get; set; }
        public CategoryTypeJournal CatgoryJournal { get; set; }



        public AbstractItem(string name , string author , long isbm, double price, int copies, DateTime date, double disount, int stock , CategoryType category , CategoryTypeJournal categoryJournal)
        {
            Name = name;
            Auther = author;
            ISBN = isbm;
            Price = price;
            DatePrint = date;
            Copies = copies;
            Discount = disount;
            Stock = stock;
            Catgory = category;
            CatgoryJournal = categoryJournal;

        }
 

    }
}
