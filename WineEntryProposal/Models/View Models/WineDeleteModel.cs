using System.Collections.Generic;


// Some of the coding in this portion of the project refers to data from Title 27 of the Code of Federal Regulations (Alcohol, Tobacco, and Firearms), Part 4 - Labeling and Advertising of Wine 

namespace WineEntryProposal.Models.ViewModels
{
    public class WineDeleteViewModel
    {
        public int id { get;  set;}
        public double ABV { get; set; }
        public string Name { get; set; }
        public GrapeVarietal GrapeVarietal { get; set; }
        public string AVA { get; set; }
        public double? btlVol { get; set; }
        public string btlVolUOM { get; set; }
        public double? fluidOz { get; set; }
        public WineType Winetype { get; set; }
        public TTBWineClass TTBWineClass { get; set; }

    }

}