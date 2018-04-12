using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineEntryProposal.Models
{
    public class ZipCodeModel
    {
        public string originZipCode {get; set;}
        public string[] destinationZipCodes { get; set; }
        public string originState { get; set; }
        public string [] destinationStates { get; set; }
        public string originCity { get; set; }
        public string [] destinationCities { get; set; }
    }
}