using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class COAs_model
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public int? RequestID { get; set; }
            public string COAID { get; set; }
            public string ProductName { get; set; }
            public string PreexistingCOAID { get; set; }
            public string LicenseType { get; set; }
            public string ProductKey { get; set; }
            public string PDFlanguage { get; set; }
            public string RecipientOrganizationName { get; set; }
            public string RecipientCity { get; set; }
            public string RecipientCountryRegion { get; set; }
            public string RecipientType { get; set; }
        }

        public class RecipientCountry
        {
            public string Region { get; set; }
        }

    }
}