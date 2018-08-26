using General.Domian.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Domian
{
    public class _DbContext : DbContext
    {
        public _DbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<SysUser> SysUsers { get; set; }
    }
}
