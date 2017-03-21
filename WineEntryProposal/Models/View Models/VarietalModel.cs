using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

// Some of the coding in this portion of the project refers to data from Title 27 of the Code of Federal Regulations (Alcohol, Tobacco, and Firearms), Part 4 - Labeling and Advertising of Wine 

namespace WineEntryProposal.Models.ViewModels
{
    public class VarietalModel
    {
        [Required]
        public int VarietalId { get; set; }

        // E.G. Chardonnay or Concord, Vidal Blanc, or Pinot Noir
        [Required, StringLength(64)]
        public string Name { get; set; }

        // E.G. Vitis Labrusca, Vitis Riparia, Vitis Vinifera
        [/*Required, */StringLength(64)]
        public string grapeFam { get; set; }

        //[Range(1, 12)]
        public int? coldHardyZone { get; set; }

        public string pictureUrl { get; set; }
    }

}