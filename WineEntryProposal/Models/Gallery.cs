using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineEntryProposal.Models
{
    public class Gallery
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
    }

    public class GallerySeed
    {
        public int ID { get; set; }
        public string ImagePathSeed { get; set; }
    }
}