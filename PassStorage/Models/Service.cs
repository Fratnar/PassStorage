using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassStorage.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual ICollection<ServiceAccount> ServiceAccounts { get; set; }

        public virtual ApplicationUser UserRef { get; set; }
    }
}