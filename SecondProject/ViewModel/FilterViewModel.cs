using BookLibrary;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject.ViewModel
{
    public class FilterViewModel : ViewModelBase, INotifyPropertyChanged
    {

        #region FieldsForFilter
        private string filterName;
        public string FilterName
        {
            get => filterName; set
            {
                Set(ref filterName, value);

                OnPropertyChanged("FilterText");
            }
        }


        private string filterAuthor;
        public string FilterAuthor
        {
            get => filterAuthor; set
            {
                Set(ref filterAuthor, value);
                OnPropertyChanged("FilterAuthor");

            }
        }


        private long filterIsbm;
        public long FilterIsbm
        {
            get => filterIsbm; set
            {
                Set(ref filterIsbm, value);
                OnPropertyChanged("FilterIsbm");

            }
        }


        private double filterPrice;
        public double FilterPrice
        {
            get => filterPrice; set
            {
                Set(ref filterPrice, value);
                OnPropertyChanged("FilterPrice");


            }
        }


        private bool checkName;
        public bool CheckName { get => checkName; set => Set(ref checkName, value); }


        private bool checkIsbm;
        public bool CheckIsbm { get => checkIsbm; set => Set(ref checkIsbm, value); }


        private bool checkAuthor;
        public bool CheckAuthor { get => checkAuthor; set => Set(ref checkAuthor, value); }


        private bool checkPrice;
        public bool CheckPrice { get => checkPrice; set => Set(ref checkPrice, value); }
        #endregion


        #region RelayCommand
        public RelayCommand ShowAll { get; set; }
        public RelayCommand SearchBen { get; set; }
        #endregion

        #region IDATA
        private readonly IDataServiceFilter serviceFilter;
        #endregion

        #region OBSList
        public static ObservableCollection<AbstractItem> ObsList;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        public FilterViewModel(IDataServiceFilter serviceFilter, ListViewModel lsv)
        {
            this.serviceFilter = serviceFilter;

            SearchBen = new RelayCommand(FilterInLV);
            ShowAll = new RelayCommand(ShowTheList);

        }

        #region Function
        private void ShowTheList()
        {
            serviceFilter.FilterFunc("", "", -1, -1, false, false, false, false);
        }

        private void FilterInLV()
        {
            serviceFilter.FilterFunc(filterName, filterAuthor, filterIsbm, filterPrice, checkName, checkIsbm, checkAuthor, checkPrice);

        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
