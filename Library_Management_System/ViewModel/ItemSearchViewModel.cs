using Library_Management_System.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace Library_Management_System.ViewModel
{
    public class ItemSearchViewModel : INotifyPropertyChanged
    {
        private readonly LibraryContext dbContext;
        private readonly DbQueryController dbQueryController;


        // checkboxes in the view
        private ObservableCollection<ItemColumn> itemColumns;
        public ObservableCollection<ItemColumn> ItemColumns
        {
            get
            {
                if (itemColumns == null)
                    itemColumns = new ObservableCollection<ItemColumn>();
                return itemColumns;
            }
            set
            {
                if (itemColumns != value)
                {
                    itemColumns = value;
                    OnPropertyChanged(nameof(ItemColumns));
                }
            }
        }
        


        private DataTable _dataTable;
        public DataTable DataTable
        {
            get { return _dataTable; }
            set
            {
                _dataTable = value;
                OnPropertyChanged(nameof(DataTable));
            }
        }



        private ObservableCollection<SearchCriteria> _searchCriteriaCollection;
        public ObservableCollection<SearchCriteria> SearchCriteriaCollection
        {
            get
            {
                if (_searchCriteriaCollection == null)
                    _searchCriteriaCollection = new ObservableCollection<SearchCriteria>();
                return _searchCriteriaCollection;
            }
            set
            {
                if (_searchCriteriaCollection != value)
                {
                    _searchCriteriaCollection = value;
                    OnPropertyChanged(nameof(SearchCriteriaCollection));
                }
            }
        }



        private ObservableCollection<string> tableNames;
        public ObservableCollection<string> TableNames
        {
            get { return tableNames; }
            set
            {
                if (tableNames != value)
                {
                    tableNames = value;
                    OnPropertyChanged(nameof(TableNames));
                }
            }
        }



        private string selectedTable;
        public string SelectedTable
        {
            get { return selectedTable; }
            set
            {
                if (selectedTable != value)
                {
                    selectedTable = value;

                    FillGrid();
                    OnPropertyChanged(nameof(SelectedTable));
                }
            }
        }



        private ObservableCollection<string> columnsFromDatabase;
        public ObservableCollection<string> ColumnNamesFromDatabase
        {
            get { return columnsFromDatabase; }
            set
            {
                columnsFromDatabase = value;
                OnPropertyChanged(nameof(ColumnNamesFromDatabase));
                
            }
        }




        private ObservableCollection<string> searchableColumns;
        public ObservableCollection<string> SearchableColumns
        {
            get 
            {
                if (searchableColumns == null)
                    searchableColumns = new ObservableCollection<string>();
                return searchableColumns;
            }
            set
            {
                if (searchableColumns != value)
                    searchableColumns = value;
                OnPropertyChanged(nameof(SearchableColumns));
            }
        }




        private ICommand searchItemCommand;
        public ICommand SearchTableCommand
        {
            get
            {
                if (searchItemCommand == null)
                {
                    searchItemCommand = new RelayCommand(param => this.FillGrid(),
                        param => true);
                }
                return searchItemCommand;
            }
        }




        public ICommand AddCriteriaCommand
        {
            get => new RelayCommand((x) =>
            {
                SearchCriteriaCollection.Add(new SearchCriteria());
            });
        }


        public ICommand RemoveCriteriaCommand
        {
            get => new RelayCommand((x) =>
            {
                var selectedItems = SearchCriteriaCollection.Where(o => o.IsSelected);

                foreach (var item in selectedItems.ToList())
                {
                    SearchCriteriaCollection.Remove(item);
                }
            });
        }


        public ICommand SearchCommand
        {
            get => new RelayCommand((x) =>
            {
                if (string.IsNullOrEmpty(SelectedTable))
                {
                    MessageBox.Show("Please select a table");
                    return;
                }

                string sqlQuery = dbQueryController.QueryStringGenerator(SearchCriteriaCollection, SelectedTable);

                DataTable = dbQueryController.ExecuteDbControllerQuery(sqlQuery);
            });
        }


        public ICommand ItemColumnSelectionChanedCommand
        {
            get => (new RelayCommand((x) =>
            {
                //filter
                SearchableColumns = new ObservableCollection<string>(
                                            ItemColumns.Where(column => column.IsSearchable).Select(column => column.Name));
            }));
        }


        public ItemSearchViewModel()
        {
            dbContext = new LibraryContext();
            dbQueryController = new DbQueryController();

            tableNames = new ObservableCollection<string>(
                dbContext.Database.SqlQuery<string>(
                    "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='LibrarySystem' AND TABLE_NAME NOT LIKE '__MigrationHistory'"
                ));
        }


        
        // method to get the columns from the database table:
        private void GetTableColumns(string tableName)
        {
            ObservableCollection<string> columns = new ObservableCollection<string>(dbContext.Database.SqlQuery<string>(
                    $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'")
                .ToList());

            if (itemColumns == null)
            {
                itemColumns = new ObservableCollection<ItemColumn>();
            }
            else
            {
                itemColumns.Clear();
            }

            //itemColumns.Clear();
            foreach (var column in columns)
            {
                ItemColumn item = new ItemColumn(column, true);
                itemColumns.Add(item);
            }

            SearchableColumns.Clear();
            foreach (var item in itemColumns)
            {
                SearchableColumns = new ObservableCollection<string>(
                            ItemColumns.Where(column => column.IsSearchable).Select(column => column.Name));
            }
            

            //return columns;
        }


        private void FillGrid()
        {
            GetTableColumns(selectedTable);
            DataTable = dbQueryController.ExecuteDbControllerQuery(dbQueryController.SelectWholeTable(SelectedTable));
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

