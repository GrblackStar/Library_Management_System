using System.Collections.ObjectModel;

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
