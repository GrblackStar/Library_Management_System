using Library_Management_System.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace Library_Management_System.ViewModel
{
    public class ItemSearchViewModel : INotifyPropertyChanged
    {
        private readonly LibraryContext dbContext;

        private ObservableCollection<string> tableNames;
        private string selectedTable;

        private ICommand searchItemCommand;

        private DataTable _dataTable;
        public DataTable DataTable
        {
            get { return _dataTable; }
            set
            {
                _dataTable = value;
                OnPropertyChanged("DataTable"); // Notify property change
            }
        }


        public ICommand SearchTableCommand
        {
            get
            {
                if (searchItemCommand == null)
                {
                    searchItemCommand = new RelayCommand(FillGrid);
                }
                return searchItemCommand;
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

                var whereQuery = "";
                foreach (var item in SearchCriteriaCollection)
                {
                    if (string.IsNullOrEmpty(item.ColumnName) || string.IsNullOrEmpty(item.Value))
                        continue;

                    if (whereQuery == "")
                        whereQuery += item.ColumnName + " LIKE '%" + item.Value + "%' ";
                    else
                        whereQuery += " AND " + item.ColumnName + " LIKE '%" + item.Value + "%' ";
                }

                if (!string.IsNullOrEmpty(whereQuery))
                {
                    whereQuery = " WHERE " + whereQuery;
                }

                // Write your raw SQL query
                string sqlQuery = "SELECT * FROM " + SelectedTable + whereQuery;


                ExecuteQuery(sqlQuery);
            });
        }


        private void ExecuteQuery(string sqlQuery)
        {
            // Execute the query and save the result into a DataTable
            var dataTable = new DataTable();
            using (var connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                connection.Open();
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            // Assign the filled DataTable to your ViewModel property
            DataTable = dataTable;
        }


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

        public string SelectedTable
        {
            get { return selectedTable; }
            set
            {
                if (selectedTable != value)
                {
                    selectedTable = value;

                    // get the columns from the database table:

                    ColumnNamesFromDatabase = GetTableColumns(selectedTable);

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
                OnPropertyChanged("ColumnNamesFromDatabase");
            }
        }



        public ItemSearchViewModel()
        {
            dbContext = new LibraryContext();

            tableNames = new ObservableCollection<string>(
                dbContext.Database.SqlQuery<string>(
                    "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='LibrarySystem' AND TABLE_NAME NOT LIKE '__MigrationHistory'"
                ));


        }



        // method to get the columns from the database table:
        private ObservableCollection<string> GetTableColumns(string tableName)
        {
            ObservableCollection<string> columns = new ObservableCollection<string>(dbContext.Database.SqlQuery<string>(
                    $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'")
                .ToList());

            return columns;
        }

        private void FillGrid(object gridParam)
        {
            ExecuteQuery($"SELECT * FROM {SelectedTable}");

        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

