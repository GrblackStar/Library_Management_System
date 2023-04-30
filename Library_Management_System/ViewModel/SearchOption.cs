using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.ViewModel
{
    public class SearchOption
    {
        public ObservableCollection<string> Items { get; set; }

        public SearchOption()
        {
            Items = new ObservableCollection<string>
            {
               "Title",
               "Author",
               "ISBN",
               "STATUS",
               "CODEID"
            };
        }
    }
}
