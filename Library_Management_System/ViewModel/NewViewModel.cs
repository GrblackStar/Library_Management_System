using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.ViewModel
{
    public class NewViewModel : ItemSearchViewModel
    {
        public NewViewModel() : base()
        {
            // Set the SelectedTable property to "books"
            SelectedTable = "books";
        }

        
    }
}
