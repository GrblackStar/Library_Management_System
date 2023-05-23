using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Model
{
    public class TableResult
    {
        public TableResult()
        {
            Columns = new ObservableCollection<ItemColumn>();
            Items = new ObservableCollection<ObservableCollection<string>>();
        }

        public ObservableCollection<ItemColumn> Columns { get; set; }

        public ObservableCollection<ObservableCollection<string>> Items { get; set; }
    }
}
