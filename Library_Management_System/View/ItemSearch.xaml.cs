using Library_Management_System.ViewModel;
using System.Windows;


namespace Library_Management_System.View
{
    /// <summary>
    /// Interaction logic for ItemSearch.xaml
    /// </summary>
    public partial class ItemSearch : Window
    {
        public ItemSearch()
        {
            InitializeComponent();
            DataContext = new ItemSearchViewModel();
        }
    }
}
