using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication16.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int PersonId {get; set;}
        public string FileName { get; set; }
    }
}