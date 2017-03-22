using System.ComponentModel.DataAnnotations;

// Some of the coding in this portion of the project refers to data from Title 27 of the Code of Federal Regulations (Alcohol, Tobacco, and Firearms), Part 4 - Labeling and Advertising of Wine 

namespace WineEntryProposal.Models.ViewModels
{
    public class VarietalModel
    {
        [Required]
        public int VarietalId { get; set; }

        // E.G. Chardonnay or Concord, Vidal Blanc, or Pinot Noir
        [StringLength(64)]
        public string VarietalName { get; set; }

        // E.G. Vitis Labrusca, Vitis Riparia, Vitis Vinifera
        [/*Required, */StringLength(64)]
        public string GrapeFam { get; set; }

        //[Range(1, 12)]
        public int? VarietalColdHardyZone { get; set; }

        public string VarietalpictureUrl { get; set; }
    }

}