using Kwitter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Kweet> Kweets { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
