using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAulas.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAulas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Pessoa> pessoa { get; set; }
    }
}
