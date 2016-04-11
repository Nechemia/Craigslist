using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication16.Models
{
    public class PersonProductItem
    {
        public int PersonProductId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public int ItemId { get; set; }
    }
}