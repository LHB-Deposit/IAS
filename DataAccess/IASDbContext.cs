using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class IASDbContext : DbContext
    {

        public IASDbContext() : base("name=IAS1DB")
        {
        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
