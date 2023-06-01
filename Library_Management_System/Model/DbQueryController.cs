using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace Library_Management_System.Model
{
    public class DbQueryController
    {
        public DbQueryController() { }

        public DataTable ExecuteDbControllerQuery(string sqlQuery)
        {
            // Execute the query and save the result into a DataTable
            DataTable dataTable = new DataTable();
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
            return dataTable;
        }



        public string QueryStringGenerator(ObservableCollection<SearchCriteria> SearchCriteriaCollection, string SelectedTable)
        {
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


            return sqlQuery;
        }



        public string SelectWholeTable(string SelectedTable)
        {
            return ($"SELECT * FROM {SelectedTable}");
        }



    }
}
