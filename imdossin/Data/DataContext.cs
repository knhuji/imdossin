using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using imdossin.Models;
using Microsoft.Extensions.Options;

namespace imdossin.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        //public DbSet<Account> Accounts { get; set; }
    }
}
