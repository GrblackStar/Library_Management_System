using Library_Management_System.Model;
using Library_Management_System.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
        private readonly LibraryContext dbContext;
        private ObservableCollection<string> tableNames;
        private string selectedTable;

        private ICommand searchItemCommand;

        private DataGrid dataGrid;
        private TableResult tableItems;

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


        public ObservableCollection<string> TableNames
        {
            get { return tableNames; }
            set
            {
                if (tableNames !=  value)
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
                    OnPropertyChanged(nameof(SelectedTable));
                }
            }
        }

        /*
        public List<string> ColumnNamesFromDatabase
        {
            get { return columnsFromDatabase; }
            set
            {
                columnsFromDatabase = value;
                OnPropertyChanged("TableNames");
            }
        }
        */

        public TableResult TableItems
        {
            get { return tableItems; }
            set 
            { 
                if(tableItems != value)
                {
                    tableItems = value;
                    OnPropertyChanged(nameof(TableItems));
                }
            }
        }

        /*
        public TableResult AvailableTables
        {
            get { return availableTables; }
            set 
            { 
                if (availableTables != value)
                {
                    availableTables = value;
                    OnPropertyChanged(nameof(AvailableTables));
                }
            }
        }
        */


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
            dbContext = new LibraryContext();
            
            tableNames = new ObservableCollection<string>(
                dbContext.Database.SqlQuery<string>(
                    "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='LibrarySystem' AND TABLE_NAME NOT LIKE '__MigrationHistory'"
                ));
            
            dataGrid = new DataGrid();
            TableItems = new TableResult();
        }



        // method to get the columns from the database table:
        private List<string> GetTableColumns(string tableName)
        {
            List<string> columns = dbContext.Database.SqlQuery<string>(
                $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'")
                .ToList();

            return columns;
        }

        private void FillGrid(object gridParam)
        {
            try
            {
                TableItems = GetTableData(selectedTable);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

            // Get a reference to the DataGrid
            DataGrid grid = (DataGrid)gridParam;
            if (dataGrid != grid)
            {
                dataGrid = grid;
            }

            // Update
            grid.ItemsSource = TableItems.Items;

            BuildGrid();
        }

        private void BuildGrid()
        {
            // Rebuild grid - we expect a new column configuration
            dataGrid.Columns.Clear();

            for (int i = 0; i < TableItems.Columns.Count; i++)
            {
                ItemColumn col = TableItems.Columns[i];

                DataGridTextColumn column = new DataGridTextColumn();
                column.Header = col.Name;
                column.Binding = new Binding($"[{i}]");
                column.IsReadOnly = true;
                dataGrid.Columns.Add(column);
                
            }

            dataGrid.Items.Refresh();
        }




        public TableResult GetTableData(string tableName, string sqlCondition = "", string columnNames = "")
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect);

            string sqlQuery = $"SELECT * FROM {tableName}";
            if (columnNames != null && columnNames != "")
            {
                sqlQuery = $"SELECT {columnNames} FROM {tableName}";
            }

            if (sqlCondition != null && sqlCondition != "")
            {
                sqlQuery = $"{sqlQuery} WHERE {sqlCondition}";
            }

            IDbCommand command = new SqlCommand
            {
                Connection = (SqlConnection)connection
            };
            connection.Open();
            command.CommandText = sqlQuery;
            IDataReader reader = command.ExecuteReader();

            bool notEndOfResult;
            notEndOfResult = reader.Read();

            TableResult result = new TableResult();
            bool readColNames = true;
            int rowNumber = 1;

            

            // For each result row:
            while (notEndOfResult)
            {
                ObservableCollection<string> row = new ObservableCollection<string>();
                
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    // Columns
                    if (readColNames)
                    {
                        string colName = reader.GetName(i);
                        ItemColumn col = new ItemColumn(colName);
                        result.Columns.Add(col);
                    }
                    // Row values
                    string value = reader.GetValue(i).ToString() ?? "";
                    row.Add(value);
                }

                readColNames = false;
                result.Items.Add(row);
                notEndOfResult = reader.Read();
                rowNumber++;
            }

            return result;


        }
       


        /*
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

            
            using (var db = new LibraryContext())
            {
                List<dynamic> items = db.{selectedTable}.ToList();
                Entities = new ObservableCollection<dynamic>(items);
            }
            

        }
    */

        /*
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
        */



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
