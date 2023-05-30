
namespace Library_Management_System.Model
{
    public class SearchCriteria
    {
        // IsSelected is used for the chechbox to see what is to be removed as a criteria
        public bool IsSelected { get; set; } = false;

        public string ColumnName { get; set; }
        public string Value { get; set; }

    }
}
