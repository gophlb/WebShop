using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string HouseNumber { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        public string Email { get; set; }
    }
}