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
        // defines a collection of search options for books.
        // It has only one property, Items, which is an ObservableCollection<string> object.
        // The Items property is initialized with a collection of search options in the class constructor.
        // The search options are "Title", "Author", "ISBN", "STATUS", and "CODEID".
        // These search options are used in the BookSearchViewModel class to allow the user to select a search criterion.
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
