using Library_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class LibraryContext : DbContext
    {
        // manage the interaction with the database
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public LibraryContext() : base(Properties.Settings.Default.DbConnect)
        {

        }


    }
}
