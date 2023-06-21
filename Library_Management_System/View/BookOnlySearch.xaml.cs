using Library_Management_System.ViewModel;
using System.Windows;


namespace Library_Management_System.View
{
    /// <summary>
    /// Interaction logic for BookOnlySearch.xaml
    /// </summary>
    public partial class BookOnlySearch : Window
    {

        //private readonly ItemSearchViewModel viewModel;

        public BookOnlySearch()
        {
            InitializeComponent();
            DataContext = new NewViewModel();

            /*
            viewModel = new ItemSearchViewModel();

            viewModel.SelectedTable = "books";

            DataContext = viewModel;
            */

        }
    }
}
