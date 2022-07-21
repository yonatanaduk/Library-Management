using BookLibrary;
using BookLibrary.Servic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace SecondProject.ViewModel
{
    public class ListViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region IData
        public IDataServiceBook _serviceBook;
        public IDataServiceJournal _serviceJournal;
        public IDataServiceFilter _serviceFilter;
        private readonly IDataServicEditItem _servicEditItem;
        #endregion

        #region RelayCommand
        public RelayCommand SearchBen { get; set; }
        public RelayCommand EditBtn { get; set; }

        #endregion

        #region View
        private ICollectionView collectionView;
        public ICollectionView CollectionView
        {
            get
            {
                return collectionView;
            }
            set
            {
                collectionView = value;
                //OnPropertyChanged("CollectionView");
            }
        }
        #endregion

        #region PropertyChange
        private AbstractItem selectItem;
        public AbstractItem SelectItem
        {
            get => selectItem; set
            {
                Set(ref selectItem, value);
                ShowMessage(selectItem);
            }
        }

        public ObservableCollection<AbstractItem> ObsList;
       
        private long itemISBM;

        public long ItemISBM { get => itemISBM; set => Set(ref itemISBM, value); }

        private double itemPrice;

        public double ItemPrice { get => itemPrice; set => Set(ref itemPrice, value); }

        private int itemCopie;

        public int ItemCopie { get => itemCopie; set => Set(ref itemCopie, value); }

        private double itemDiscount;

        public double ItemDiscount { get => itemDiscount; set => Set(ref itemDiscount, value); }

        private System.Collections.IEnumerable itemCatgory;

        public System.Collections.IEnumerable ItemCatgory { get => itemCatgory; set => Set(ref itemCatgory, value); }

        private int itemStock;

        public int ItemStock { get => itemStock; set => Set(ref itemStock, value); }


        private bool checkIsbm;

        public bool CheckIsbm { get => checkIsbm; set => Set(ref checkIsbm, value); }

        private bool checkPrice;

        public bool CheckPrice { get => checkPrice; set => Set(ref checkPrice, value); }

        private bool checkCopies;

        public bool CheckCopies { get => checkCopies; set => Set(ref checkCopies, value); }

        private bool checkStock;

        public bool CheckStock { get => checkStock; set => Set(ref checkStock, value); }

        private bool checkDiscount;

        public bool CheckDiscount { get => checkDiscount; set => Set(ref checkDiscount, value); }
        #endregion

        public ListViewModel(IDataServiceBook serviceBook, IDataServiceJournal serviceJournal, IDataServiceFilter serviceFilter, IDataServicEditItem servicEditItem)
        {
            _serviceBook = serviceBook;
            _serviceJournal = serviceJournal;
            _serviceFilter = serviceFilter;
            _servicEditItem = servicEditItem;

            _serviceBook.AddBooksEvent += AddBookToCollection;
            _serviceJournal.AddJournalEvent += AddJounralToCollection;
            _serviceFilter.Refresh += RefreshingFunction;
            _serviceBook.MessageBooks += MessageForUser;
            _serviceBook.MessageInvalid += MessageInvalidInput;
            _serviceJournal.MessageJournal += MessageForUser;
            _serviceJournal.MessageInvalidJournal += MessageInvalidInput;
            _serviceFilter.MessageNotFounded += MessageFilterNotFounded;


            EditBtn = new RelayCommand(EditTheItem);
            ObsList = new ObservableCollection<AbstractItem>();
            CollectionView = CollectionViewSource.GetDefaultView(ObsList);

        }


        #region Message
        private void MessageForUser()
        {
            MessageBox.Show("Can't have the same ISBN twice!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void MessageFilterNotFounded()
        {
            MessageBox.Show("the system not found your product!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void MessageInvalidInput()
        {
            MessageBox.Show("Sorry , your input is wrong! \n try again.!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public void ShowMessage(AbstractItem item)
        {
            if (item != null)
            {
                MessageBox.Show($"the name is:{ selectItem.Name}\n Author:{selectItem.Auther} \n ISBN: {selectItem.ISBN} \n Price:{selectItem.Price} \n Copis: {selectItem.Copies} " +
                    $"\n Discount: {selectItem.Discount} \n CategoryBook: {selectItem.Catgory}  / CatrgoryJournal: {selectItem.CatgoryJournal} \n Stock: {selectItem.Stock} \n DatePrint : {selectItem.DatePrint} ");
            }

        }
        #endregion

        #region FunctionAddingToListView  
        private void AddJounralToCollection(AbstractItem obj) => ObsList.Add(obj);
        private void AddBookToCollection(AbstractItem obj) => ObsList.Add(obj);
        #endregion

        #region refreshView
        private void RefreshingFunction(List<AbstractItem> obj)
        {
            ObsList.Clear();
            if (obj != null)
            {
                foreach (AbstractItem item in obj)
                {
                    
                    ObsList.Add(item);
                }
            }
            CollectionView = CollectionViewSource.GetDefaultView(obj);
        }
        private void EditTheItem()
        {

            _servicEditItem.EditItems(ref selectItem, itemISBM, itemPrice, itemCopie, itemDiscount, itemStock, checkIsbm , checkPrice , checkCopies , checkDiscount , checkStock);


            ShowMessage(selectItem);
            CollectionView.Refresh();

        }
        #endregion

    }
}
