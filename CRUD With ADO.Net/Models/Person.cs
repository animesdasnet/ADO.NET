using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_With_ADO.Net.Models
{
    public class Person
    {
        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailPromotion { get; set; }
    }
}