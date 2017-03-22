using System.ComponentModel.DataAnnotations;

// Some of the coding in this portion of the project refers to data from Title 27 of the Code of Federal Regulations (Alcohol, Tobacco, and Firearms), Part 4 - Labeling and Advertising of Wine 

namespace WineEntryProposal.Models.ViewModels
{

    public class WineModel
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public WineType WineType { get; set; }

        public string AVA { get; set; }

        public double ABV { get; set; }

        public double? fluidOz { get; set; }
        [Required]
        public double? btlVol { get; set; }
        [Required]
        public string btlVolUOM { get; set; }

        [Required]
        public VarietalModel Varietal { get; set; }

    }
}