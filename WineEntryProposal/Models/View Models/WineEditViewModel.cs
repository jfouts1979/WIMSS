using System.Collections.Generic;

// Some of the coding in this portion of the project refers to data from Title 27 of the Code of Federal Regulations (Alcohol, Tobacco, and Firearms), Part 4 - Labeling and Advertising of Wine 

namespace WineEntryProposal.Models.ViewModels
{
    public class WineEditViewModel
    {

        public WineModel TheWine { get; set; }
        public List<GrapeVarietal> VarietalsToChooseFrom { get; set; }
        public GrapeVarietal GrapeVarietal { get; set; }
        public bool? ShowSuccessMsg { get; set; }
        public TTBWineClass TheWineClass { get; set; }
        public int SelectedVarietalId { get; set; }

    }

}