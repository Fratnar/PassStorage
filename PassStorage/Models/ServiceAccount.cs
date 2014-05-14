using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassStorage.Models
{
    public class ServiceAccount
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int ServiceId { get; set; }
        public string Password { get; set; }
    }
}