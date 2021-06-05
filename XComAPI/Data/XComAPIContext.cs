using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XComAPI.Data;

namespace XComAPI.Data
{
    public class XComAPIContext : DbContext
    {
        public XComAPIContext (DbContextOptions<XComAPIContext> options)
            : base(options)
        {
        }

        public DbSet<XComAPI.Data.Client> Client { get; set; }

        public DbSet<XComAPI.Data.Event> Event { get; set; }
    }
}
