using Library_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class LibraryContext : DbContext
    {

        public LibraryContext() : base(Properties.Settings.Default.DbConnect)
        {

        }
        // manage the interaction with the database
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Book entity
            modelBuilder.Entity<Book>()
                .HasKey(b => b.BookId)
                .Property(b => b.BookId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Disable database-generated IDs for this entity

            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.Author)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.ISBN)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.CopyID)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.Status)
                .HasMaxLength(20)
                .IsRequired();

            // Configure Client entity
            modelBuilder.Entity<Client>()
                .HasKey(c => c.ClientId)
                .Property(c => c.ClientId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Disable database-generated IDs for this entity

            modelBuilder.Entity<Client>()
                .Property(c => c.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.LastName)
                .HasMaxLength(50)
                .IsRequired();

            // Configure Admin entity
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.AdminId)
                .Property(a => a.AdminId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Disable database-generated IDs for this entity

            modelBuilder.Entity<Admin>()
                .Property(a => a.Username)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Admin>()
                .Property(a => a.Password)
                .HasMaxLength(50)
                .IsRequired();
        }

    }
}
