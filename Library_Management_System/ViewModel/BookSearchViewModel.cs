using Library_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Library_Management_System.ViewModel
{
    public class BookSearchViewModel : INotifyPropertyChanged
    {
        // provides data and behavior to a view that displays a list of books and allows the user to search for books.
        // The class implements the INotifyPropertyChanged interface, which allows the view to be notified when a
        // property of the view model changes

        // The _entities property is an ObservableCollection<Book> object that contains the books to be displayed in the view.
        private ObservableCollection<Book> _entities;
        // The _view property is an ICollectionView object that provides a filtered and sorted view of the _entities collection
        private ICollectionView _view;
        // contains a list of search options that are used to allow the user to select a search criterion
        private List<string> _items = new List<string>()
        {
            "ALL",
            "Title",
            "Author",
            "ISBN",
            "STATUS",
            "CODEID"
        };

        // The _selectedItem property is a string that represents the currently selected search criterion
        private string _selectedItem;
        // The _searchText property is a string that represents the text to be searched for.
        private string _searchText;

        // Define a command to perform the searching
        private ICommand _searchCommand;
        // Define a command to perform the sorting
        public ICommand SortCommand => new RelayCommand(param => this.Sort(),
                        param => this.CanSearch());


        public bool SortByTitle { get; set; }
        public bool SortByTitleAsc { get; set; }
        public bool SortByAuthor { get; set; }
        public bool SortByAuthorAsc { get; set; }
        public bool SortByISBN { get; set; }
        public bool SortByISBNAsc { get; set; }
        public bool SortByStatus { get; set; }
        public bool SortByStatusAsc { get; set; }



        // The Sort() method is called by the SortCommand command when it is executed.
        // The method clears any existing sort descriptions from the _view object and adds new sort descriptions
        // based on the selected criteria.
        private void Sort()
        {
            if (_view == null)
            {
                return;
            }
            // Clear any existing sort descriptions
            _view.SortDescriptions.Clear();

            // Add new sort descriptions based on the selected criteria
            if (SortByTitle)
            {
                _view.SortDescriptions.Add(new SortDescription("Title", SortByTitleAsc ? ListSortDirection.Ascending : ListSortDirection.Descending));
            }

            if (SortByAuthor)
            {
                _view.SortDescriptions.Add(new SortDescription("Author", SortByAuthorAsc ? ListSortDirection.Ascending : ListSortDirection.Descending));
            }

            if (SortByISBN)
            {
                _view.SortDescriptions.Add(new SortDescription("ISBN", SortByISBNAsc ? ListSortDirection.Ascending : ListSortDirection.Descending));
            }

            if (SortByStatus)
            {
                _view.SortDescriptions.Add(new SortDescription("Status", SortByStatusAsc ? ListSortDirection.Ascending : ListSortDirection.Descending));
            }
        }

        public ObservableCollection<Book> Entities
        {
            get { return _entities; }
            set
            {
                if (_entities != value)
                {
                    _entities = value;
                    OnPropertyChanged("Entities");
                }
            }
        }

        public List<string> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged("Items");
                }
            }
        }

        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged("SearchText");
                }
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(
                            param => this.Search(),
                        param => this.CanSearch());

                }
                return _searchCommand;
            }
        }

        // called by the SearchCommand
        private bool CanSearch()
        {
            return true;
        }

        // The Search() method is called by the SearchCommand command when it is executed.
        // The method retrieves the books from the database that match the selected search
        // criterion and search text and updates the _entities collection with the results.
        // The _view object is also updated to display the filtered and sorted results.
        private void Search()
        {
            using (var db = new LibraryContext())
            {
                if (SearchText == null || SearchText.Equals(""))
                {
                    List<Book> books = db.Books.ToList();
                    Entities = new ObservableCollection<Book>(books);

                }
                else
                {
                    IQueryable<Book> result = null;
                    switch (SelectedItem)
                    {
                        case "Title":
                            result = db.Books.Where(b => b.Title.Contains(SearchText));

                            break;
                        case "Author":
                            result = db.Books.Where(b => b.Author.Contains(SearchText));
                            break;
                        case "ISBN":
                            result = db.Books.Where(b => b.ISBN.Contains(SearchText));
                            break;
                        case "Status":
                            result = db.Books.Where(b => b.Status.Contains(SearchText));
                            break;
                        case "ALL":
                            result = db.Books.Where(b => b.Title.Contains(SearchText) || b.Author.Contains(SearchText) || b.ISBN.Contains(SearchText) || b.Status.Contains(SearchText));
                            break;
                    }

                    Entities = new ObservableCollection<Book>(result.ToList());

                }
                _view = CollectionViewSource.GetDefaultView(_entities);
            }
            OnPropertyChanged("Entities");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // The OnPropertyChanged() method is a method that is called to raise the PropertyChanged event.
        // This method is used to notify the view when a property of the view model changes.
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
