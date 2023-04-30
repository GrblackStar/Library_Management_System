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
        private ObservableCollection<Book> _entities;
        private ICollectionView _view;
        private List<string> _items = new List<string>()
        {
            "ALL",
            "Title",
            "Author",
            "ISBN",
            "STATUS",
            "CODEID"
        };
        private string _selectedItem;
        private string _searchText;
        private ICommand _searchCommand;



        public bool SortByTitle { get; set; }
        public bool SortByTitleAsc { get; set; }
        public bool SortByAuthor { get; set; }
        public bool SortByAuthorAsc { get; set; }
        public bool SortByISBN { get; set; }
        public bool SortByISBNAsc { get; set; }
        public bool SortByStatus { get; set; }
        public bool SortByStatusAsc { get; set; }

        // Define a command to perform the sorting
        public ICommand SortCommand => new RelayCommand(param => this.Sort(),
                        param => this.CanSearch());

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

        private bool CanSearch()
        {
            return true;
        }

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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
