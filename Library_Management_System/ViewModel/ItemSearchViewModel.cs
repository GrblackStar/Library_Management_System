using Library_Management_System.Model;
using Library_Management_System.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Library_Management_System.ViewModel
{
    public class ItemSearchViewModel : INotifyPropertyChanged
    {
        private readonly LibraryContext _dbContext;
        private ObservableCollection<TableName> _tableNames;
        private string _selectedTable;
        private List<string> _columnsFromDatabase;

        private ObservableCollection<dynamic> _entities;
        private ICollectionView view;

        private ICommand searchItemCommand;






        public ICommand SearchTableCommand
        {
            get
            {
                if (searchItemCommand == null)
                {
                    searchItemCommand = new RelayCommand(
                            param => this.SearchTable(),
                        param => this.CanCallMethod());

                }
                return searchItemCommand;
            }
        }

        public ObservableCollection<TableName> TableNames
        {
            get { return _tableNames; }
            set
            {
                _tableNames = value;
                OnPropertyChanged("TableNames");
            }
        }

        public string SelectedTable
        {
            get { return _selectedTable; }
            set
            {
                if (_selectedTable != value)
                {
                    _selectedTable = value;
                    OnPropertyChanged("SelectedTable");
                }
            }
        }

        public List<string> ColumnNamesFromDatabase
        {
            get { return _columnsFromDatabase; }
            set
            {
                _columnsFromDatabase = value;
                OnPropertyChanged("TableNames");
            }
        }

        public ObservableCollection<dynamic> Entities
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

        /*
        private ListView ItemListView;
        public ItemSearchViewModel()
        {
            // Other code...

            Loaded += ItemSearchViewModel_Loaded;
        }

        private void ItemSearchViewModel_Loaded(object sender, RoutedEventArgs e)
        {
            ItemListView = FindName("ItemListView") as ListView;
        }
        */


        public ItemSearchViewModel()
        {
            _dbContext = new LibraryContext();
            _tableNames = new ObservableCollection<TableName>(
                _dbContext.Database.SqlQuery<string>(
                    "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='LibrarySystem' AND TABLE_NAME NOT LIKE '__MigrationHistory'"
                ).Select(t => new TableName { Name = t })
            );
        }



        // method to get the columns from the database table:
        private List<string> GetTableColumns(string tableName)
        {
            List<string> columns = _dbContext.Database.SqlQuery<string>(
                $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'")
                .ToList();

            return columns;
        }

        private void SearchTable()
        {
            List<string> columns = GetTableColumns(SelectedTable);
            // make columns:


            GetDataByTable(SelectedTable);

        }

        private void GetDataByTable(string selectedTable)
        {
            // static implementation:
            if (selectedTable == "Books")
            {
                using (var db = new LibraryContext())
                {
                    List<Book> books = db.Books.ToList();
                    Entities = new ObservableCollection<dynamic>(books);

                    view = CollectionViewSource.GetDefaultView(_entities);
                }
                
                OnPropertyChanged("Entities");
            }

            /*
            using (var db = new LibraryContext())
            {
                List<dynamic> items = db.{selectedTable}.ToList();
                Entities = new ObservableCollection<dynamic>(items);
            }
            */

        }

        private void InitializeListViewColumns(List<string> columns)
        {
            
            var listViewColumns = new ObservableCollection<GridViewColumn>();
            foreach (var columnName in columns)
            {
                var column = new GridViewColumn
                {
                    Header = columnName,
                    DisplayMemberBinding = new Binding(columnName)
                };
                listViewColumns.Add(column);
            }
            // get the list view by name
            //_listView.Columns = listViewColumns;
        }













        private bool CanCallMethod()
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
