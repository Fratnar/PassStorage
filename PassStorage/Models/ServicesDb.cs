using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PassStorage.Models
{
    public class ServicesDb : IdentityDbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceAccount> ServiceAccounts { get; set; }
    }
}