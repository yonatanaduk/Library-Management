using BookLibrary;
using BookLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static BookLibrary.Book;
using static BookLibrary.Journal;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        readonly ItemCollection _itc = new ItemCollection();
        readonly ItemCollectionBook _itcBook = new ItemCollectionBook();
        readonly ItemCollectionJournal _itcJournal = new ItemCollectionJournal();
        readonly Book _book = new Book("yonatan", "aduk", 11223344, 55.5, 100, DateTime.Parse("1/1/2012 12:00:00"), 25, 60, CategoryType.Action, 0);
        readonly Book book = new Book("yonatan", "aduk", 112244, 55.5, 100, DateTime.Parse("1/1/2012 12:00:00"), 25, 60, CategoryType.Action, 0);
        readonly Journal _journal = new Journal("yonatan", "aduk", 1122344, 55.5, 100, DateTime.Parse("1/1/2012 12:00:00"), 25, 60, 0, CategoryTypeJournal.Newspaper);

        [TestMethod]
        public void CheckAddingBook()
        {

            Assert.IsTrue(_itcBook.AddBook(_book.Name, _book.Auther, _book.ISBN, _book.Price, _book.Copies, _book.DatePrint, _book.Discount, _book.Stock, _book.Catgory, 0));

        }
        [TestMethod]
        public void ChakingNotNullBook()
        {

            Assert.IsNotNull(_itcBook.AddBook(book.Name, book.Auther, book.ISBN, book.Price, book.Copies, book.DatePrint, book.Discount, book.Stock, book.Catgory, 0));

        }

        [TestMethod]
        public void CheckAddingJournal()
        {

            Assert.IsNotNull(_itcJournal.AddJornal(_journal.Name, _journal.Auther, _journal.ISBN, _journal.Price, _journal.Copies, _journal.DatePrint, _journal.Discount, _journal.Stock, 0, _journal.CatgoryJournal));

        }
        public void ChackNotNullJournal()
        {

            Assert.IsTrue(_itcJournal.AddJornal(_journal.Name, _journal.Auther, _journal.ISBN, _journal.Price, _journal.Copies, _journal.DatePrint, _journal.Discount, _journal.Stock, 0, _journal.CatgoryJournal));

        }


        [TestMethod]
        public void CheckFilter()
        {
            Assert.IsTrue(_itc.FilterFunc("drive", "mountain", 112233, 10, true, false, true, false).GetType() == typeof(List<AbstractItem>));
        }

        [TestMethod]
        public void CheckEditForBook()
        {
            var Abstract = _book as AbstractItem;
            Assert.IsTrue(_itc.EditItems(ref Abstract, 112233 , 55 ,100 ,50 ,150 , true , false , true ,false , true));
        }

        [TestMethod]
        public void CheckEditForJournal()
        {
            var Abstract =  _journal as AbstractItem;
            Assert.IsTrue(_itc.EditItems(ref Abstract, 112233, 55, 100, 50, 150, true, false, true, false, true));
        }

    }
}

