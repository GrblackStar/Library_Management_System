namespace Library_Management_System.Model
{
    public class ItemColumn
    {
        public string Name { get; set; }
        public bool IsSearchable { get; set; }

        public ItemColumn() { }
        public ItemColumn(string name, bool isSearchable)
        {
            Name = name;
            IsSearchable = isSearchable;
        }

    }
}
