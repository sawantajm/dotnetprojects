using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsingConsole.Entity
{
    public  class DatabaseContext:DbContext
    {

        public string ConnectionString { get; set; }
        public DatabaseContext()
        {
            ConnectionString = "Server=DESKTOP-Q650CVS;Database=CRUDConsole;Trusted_connection=true;";
        }
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
    
}
