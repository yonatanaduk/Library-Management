using System;

namespace BookLibrary
{
    public interface IDataServicEditItem
    {
        //event Action EditEvent;
        bool EditItems(ref AbstractItem item ,long isbn , double price,int copis ,double discount,int itemStock , bool checkIsbm , bool checkPrice , bool checkCopies,bool checkDiscount , bool checkStock);
    }
}