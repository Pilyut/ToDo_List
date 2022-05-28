using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ToDo> Users { get; set; } = null!;
        public string connectionString;
        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ToDoDataBase.db");
        }
    }
}