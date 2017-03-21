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
    public class WineEditViewModel
    {
        public WineModel TheWine { get; set; }
        public GrapeVarietal GrapeVarietal { get; set; }
        public bool? ShowSuccessMsg { get; set; }
    }

}