using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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
            var criteriaGroups = SearchCriteriaCollection.GroupBy(c => c.ColumnName);

            StringBuilder whereQuery = new StringBuilder();
            foreach (var group in criteriaGroups)
            {
                var column = group.Key;
                var criteria = group.ToList();

                if (string.IsNullOrEmpty(column))
                {
                    continue;
                }

                StringBuilder subQuery = new StringBuilder();
                foreach (var item in criteria)
                {
                    if (string.IsNullOrEmpty(item.Value))
                    {
                        continue;
                    }

                    if (subQuery.Length > 0)
                    {
                        subQuery.Append(" OR ");
                    }

                    subQuery.Append(column + " LIKE '%" + item.Value + "%'");
                }

                if (subQuery.Length > 0)
                {
                    if (whereQuery.Length > 0)
                    {
                        whereQuery.Append(" AND ");
                    }

                    whereQuery.Append("(" + subQuery.ToString() + ")");
                }
            }

            string whereClause = whereQuery.Length > 0 ? "WHERE " + whereQuery.ToString() : string.Empty;
            string sqlQuery = "SELECT * FROM " + SelectedTable + " " + whereClause;

            return sqlQuery;
        }




        public string SelectWholeTable(string SelectedTable)
        {
            return ($"SELECT * FROM {SelectedTable}");
        }



    }
}
