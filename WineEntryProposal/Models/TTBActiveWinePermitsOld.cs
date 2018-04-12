using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineEntryProposal.Models
{
    public class wineriesByPermitByState
    {
        public string PermitNumber { get; set; }
        public string OwnerName { get; set; }
        public string OperatingName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Zip4 { get; set; }
        public string County { get; set; }
    }
}