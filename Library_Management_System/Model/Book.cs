namespace Library_Management_System.Model
{
    public class Book : BaseModel
    {
        public string BookId { get; set; }     // in the set, concatenate copy id + ISBN
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string CopyID { get; set; }
        public string Status { get; set; }
    }
}
