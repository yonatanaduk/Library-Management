using BookLibrary.Servic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static BookLibrary.Book;
using static BookLibrary.Journal;

namespace SecondProject.ViewModel
{
    public class TextBoxViewModel : ViewModelBase
    {

        #region IData
        public IDataServiceBook _serviceBook;
        public IDataServiceJournal _serviceJournal;
        #endregion

        #region PropertyTextBoxesForBook
        private string itemName;
        public string ItemName { get => itemName; set => Set(ref itemName, value); }

        private string itemAuthor;
        public string ItemAuthor { get => itemAuthor; set => Set(ref itemAuthor, value); }

        private long itemISBM;
        public long ItemISBM { get => itemISBM; set => Set(ref itemISBM, value); }

        private double itemPrice;
        public double ItemPrice { get => itemPrice; set => Set(ref itemPrice, value); }

        private int itemCopie;
        public int ItemCopie { get => itemCopie; set => Set(ref itemCopie, value); }

        private DateTime itemDateprint;
        public DateTime ItemDateprint { get => itemDateprint; set => Set(ref itemDateprint, value); }

        private double itemDiscount;
        public double ItemDiscount
        {
            get
            {
                if (Catgory.HasFlag(CategoryType.Action) && itemDiscount < 10) itemDiscount = 10;
                if (Catgory.HasFlag(CategoryType.Romanticism) && itemDiscount < 20) itemDiscount = 20;
                if (Catgory.HasFlag(CategoryType.Comedy) && itemDiscount < 15) itemDiscount = 15;
                if (Catgory.HasFlag(CategoryType.Fictional) && itemDiscount < 22) itemDiscount = 22;
                if (Catgory.HasFlag(CategoryType.News) && itemDiscount < 5) itemDiscount = 5;

                return itemDiscount;
            }
            set { Set(ref itemDiscount, value); }
        }

        private string itemGenre;
        public string ItemGenre { get => itemGenre; set => Set(ref itemGenre, value); }

        private int itemInStock;
        public int ItemInStock { get => itemInStock; set => Set(ref itemInStock, value); }

        private CategoryType catgory;
        public CategoryType Catgory { get => catgory; set => Set(ref catgory, value); }
        #endregion

        #region PropertyTextBoxForJournal

        private string itemNameJournal;
        public string ItemNameJournal { get => itemNameJournal; set => Set(ref itemNameJournal, value); }

        private string itemAuthorJournal;
        public string ItemAuthorJournal { get => itemAuthorJournal; set => Set(ref itemAuthorJournal, value); }

        private long itemISBMJournal;
        public long ItemISBMJournal { get => itemISBMJournal; set => Set(ref itemISBMJournal, value); }

        private double itemPriceJournal;
        public double ItemPriceJournal { get => itemPriceJournal; set => Set(ref itemPriceJournal, value); }

        private int itemCopieJournal;
        public int ItemCopieJournal { get => itemCopieJournal; set => Set(ref itemCopieJournal, value); }

        private DateTime itemDateprintJournal;
        public DateTime ItemDateprintJournal { get => itemDateprintJournal; set => Set(ref itemDateprintJournal, value); }

        private double itemDiscountJournal;

        public double ItemDiscountJournal
        {
            get
            {
                if (ItemCatgoryJournal.HasFlag(CategoryTypeJournal.Newspaper) && itemDiscountJournal < 50) itemDiscountJournal = 50;
                if (ItemCatgoryJournal.HasFlag(CategoryTypeJournal.magazine) && itemDiscountJournal < 25) itemDiscountJournal = 25;
                if (ItemCatgoryJournal.HasFlag(CategoryTypeJournal.Artistic) && itemDiscountJournal < 13) itemDiscountJournal = 13;
                if (ItemCatgoryJournal.HasFlag(CategoryTypeJournal.Food) && itemDiscountJournal < 30) itemDiscountJournal = 30;
                if (ItemCatgoryJournal.HasFlag(CategoryTypeJournal.Travel) && itemDiscountJournal < 40) itemDiscountJournal = 40;

                return itemDiscountJournal;
            }
            set { Set(ref itemDiscountJournal, value); }
        }


        private CategoryTypeJournal itemCatgoryJournal;
        public CategoryTypeJournal ItemCatgoryJournal { get => itemCatgoryJournal; set => Set(ref itemCatgoryJournal, value); }

        private string itemTopicJournal;
        public string ItemTopicJournal { get => itemTopicJournal; set => Set(ref itemTopicJournal, value); }

        private int itemInStockJournal;
        public int ItemInStockJournal { get => itemInStockJournal; set => Set(ref itemInStockJournal, value); }

        #endregion

        #region RelayCommand

        private RelayCommand addJournalCommand;

        private RelayCommand addBookCommand;
        public ICommand AddJournalCommand
        {
            get
            {
                if (addJournalCommand == null)
                {
                    addJournalCommand = new RelayCommand(AddJournal);
                }

                return addJournalCommand;
            }
        }

        public ICommand AddBookCommand
        {
            get
            {
                if (addBookCommand == null)
                {
                    addBookCommand = new RelayCommand(AddBook);
                }

                return addBookCommand;
            }
        }

        #endregion


        public TextBoxViewModel(IDataServiceBook serviceBook, IDataServiceJournal serviceJournal)
        {
            _serviceBook = serviceBook;
            _serviceJournal = serviceJournal;
        }


        #region FunctionAdding
        private void AddBook()
        {
            _serviceBook.AddBook(itemName, ItemAuthor, itemISBM, itemPrice, itemCopie, itemDateprint, itemDiscount, itemInStock, catgory, itemCatgoryJournal);
            ItemName = ""; ItemAuthor = ""; ItemISBM = 0; ItemPrice = 0; ItemCopie = 0; ItemDateprint = default; ItemDiscount = 0; ItemInStock = 0; Catgory = default; ItemCatgoryJournal = default;
        }
        private void AddJournal()
        {
            _serviceJournal.AddJornal(itemNameJournal, itemAuthorJournal, itemISBMJournal, itemPriceJournal, itemCopieJournal, itemDateprintJournal, itemDiscountJournal, itemInStockJournal, catgory, itemCatgoryJournal);
            ItemNameJournal = ""; ItemAuthorJournal = ""; ItemISBMJournal = 0; ItemPriceJournal = 0; ItemCopieJournal = 0; ItemDateprintJournal = default; ItemDiscountJournal = 0; ItemInStockJournal = 0; Catgory = default; ItemCatgoryJournal = default;
        }
        #endregion


        #region WordInComboBoxes
        public Array Catgorybook => Enum.GetValues(typeof(CategoryType));
        public Array CatgoryJournal => Enum.GetValues(typeof(CategoryTypeJournal));
        #endregion

    }
}

