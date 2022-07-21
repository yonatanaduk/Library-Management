using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;

namespace BookLibrary
{
    public interface IDataServiceFilter
    {
        event Action <List<AbstractItem>>  Refresh;
        event Action MessageNotFounded;

        List<AbstractItem> FilterFunc(object str , object author , object isbm  , object price  ,bool checkName , bool checkIsbm  ,bool checkAuthor, bool checkPrice);


    }
}