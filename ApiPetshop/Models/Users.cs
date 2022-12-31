using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPetshop.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }

        public string UserMail { get; set; }

        public string UserPassword { get; set; }

        public bool IsAdmin { get; set; }
    }
}