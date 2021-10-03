using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
    public class Context : DbContext
    {

        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> headings { get; set; }
        public DbSet<Writer> writers { get; set; }

        

    }
}
