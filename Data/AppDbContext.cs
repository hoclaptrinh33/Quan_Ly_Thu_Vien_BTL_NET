using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quan_Ly_Thu_Vien_BTL_NET.Models;

namespace Quan_Ly_Thu_Vien_BTL_NET.Data
{
        public class AppDbContext : DbContext
        {
            public DbSet<Book> Books { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Reader> Readers { get; set; }
            public DbSet<Borrow> Borrow { get; set; }
            public DbSet<SystemConfig> SystemConfigs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ThuVienDB;Integrated Security=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

            }
        }
    }


