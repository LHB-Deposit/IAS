using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BankServiceCatalogue> BankServiceCatalogues { get; set; }
        public DbSet<BankService> BankServices { get; set; }
        public DbSet<ServiceVerify> ServiceVerifies { get; set; }
        public DbSet<ServiceVerifyMethod> ServiceVerifyMethods { get; set; }
    }
}
