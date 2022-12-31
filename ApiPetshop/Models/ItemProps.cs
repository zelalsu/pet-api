using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPetshop.Models
{
    public class ItemProps
    {
        public int ID { get; set; }
        public int ItemId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public string ProductProps { get; set; }
        public string Image { get; set; }

    }

}