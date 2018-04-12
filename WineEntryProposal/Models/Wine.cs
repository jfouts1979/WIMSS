using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using WineEntryProposal.Views.Wine;

// Some of the coding in this portion of the project refers to data from Title 27 of the Code of Federal Regulations (Alcohol, Tobacco, and Firearms), Part 4 - Labeling and Advertising of Wine - Subpart C - Standards of Identity for Wine - Section 4.21 - referring to nine distinct separate classes of wine.  These include:

// "Grape Wine", 
// "Sparkling Grape Wine", 
// "Carbonated Grape Wine", 
// "Citrus Wine", 
// "Fruit Wine", 
// "Wine From Other Agricultural Products", 
// "Aperitif Wine", 
// "Imitiation and Substandard or Other Than Standard Wine",
// "Retsina Wine" - Wine made from resin ??? Cannabis Wine? 

// These definitions will be documented and outlined to become clear throughout the   coding in the project and app as developed.

namespace WineEntryProposal.Models
{


    //**********************************
    //**** Wine Model ******************
    //**********************************

    public class Wine  // Data Model
    {
        [Required]
        public int Id { get; set; }

        //Government Warning That Must Appear On All Alcoholic Containers
        public const string govtWarning = "GOVERNMENT WARNING: (1) ACCORDING TO THE SURGEON GENERAL, WOMEN SHOULD NOT DRINK ALCOHOLIC BEVERAGES DURING PREGNANCY BECAUSE OF THE RISK OF BIRTH DEFECTS. (2) CONSUMPTION OF ALCOHOLIC BEVERAGES IMPAIRS YOUR ABILITY TO DRIVE A CAR OR OPERATIE MACHINERY AND MAY CAUSE HEALTH PROBLEMS.";

        // Brand name of the wine itself.  Robert Mondavi for instance or Kendall Jackson
        // Beringer or Yellowtail (sp?).  Barefoot is Kmart's brand.  
        [Required, StringLength(64)]
        public string Name { get; set; }

        [Required]
        public WineType TheWineType { get; set; }

        // American Viticultural Area ** Per Title 27 CFR ** Required If Varietal Name
        // Declared On Label Of Wine.  Must Research Further To Update Comments.
        // **************************************************************

        [StringLength(256)]
        public string AVA { get; set; }

        // Alc By Vol (ABV) is only req. on the label in certain situations.
        // Per Title 27 CFR eg wines < than 12% ABV may contain the words 'light' or 'Table' in lieu of the actual % ABV on label.

        [Range(0.0, 1.0)]
        public double ABV { get; set; }

        // public double fluidOz { get; set; }

        [Range(0.0, 1000.0)]
        public double? fluidOz { get; set; }

        // Would like to incorporate fluidOz and btlVol in the future so that
        // uom such as 33.8 fl. oz. could be used OR 750 ml for example to denote
        // bottle volume.  However, for the project at this time, will stick to 
        // K.I.S.S.  

        //*******************************************************
        //********** Bottle Information *************************
        //*******************************************************

        // Bottle volume is required per TTB rules and regulations.
        // So data annotation as noted.

        [Required, Range(0.0, 1000.0)]
        public double? btlVol { get; set; }

        [Required]
        [StringLength(8)]
        public string btlVolUOM { get; set; }
        //******************************************************
        //******************************************************
        //** Grape Varietal Pulls List From TTB Website ********
        //** Of All Currently Approved Title 27 CFR ************
        //********** Varietals.                    *************
        //******************************************************
        //YET TO BE IMPLEMENTED FULLY

        [Required]
        public GrapeVarietal TheVarietal { get; set; }

        [Required]
        public TTBWineClass TheTTBWineClass { get; set; }

        [StringLength(256)]
        public string WineryURL { get; set; }

        [StringLength(256)]
        public string Description { get; set; }


    }

    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


    //**************************************************************
    //************* Establish List of Grape Varietals***************
    //**************************************************************

    public class GrapeVarietal  // Data Model
    {
        public int Id { get; set; }

        // E.G. Chardonnay or Concord, Vidal Blanc, or Pinot Noir
        [Required, StringLength(64)]
        public string Name { get; set; }

        // E.G. Vitis Labrusca, Vitis Riparia, Vitis Vinifera
        [/*Required, */StringLength(64)]
        public string grapeFam { get; set; }

        public string pictureUrl { get; set; }
    }




  
    //public class Gallery
    //{
    //    public class SliderPic
    //    {
    //        public int Id { get; set; }
    //        public string Name { get; set; }
    //        public string ImageURL { get; set; }
    //    }
    //}



    //**************************************************************
    //*********Establish List of Non-Grape Fruit Source Types*******
    //**************************************************************

    public class NGFruitSourceType  // Data Model
    {
        public int Id { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        //Brix § 151.91 Brix values of unconcentrated natural fruit juices.
        //The following values have been determined to be the average Brix values of unconcentrated natural fruit juices in the trade and commerce of the United States, for the purposes of the provisions of the Additional U.S.Notes to Chapter 20, Harmonized Tariff Schedule of the United States(HTSUS) ( 19 U.S.C. 1202), and will be used in determining the dutiable quantity of imports of concentrated fruit juices, using the procedure set forth in Additional U.S.Note 2, Chapter 20, HTSUS:

        [Range(0.0, 100.0)]
        public double Brix { get; set; }
    }



    //*********************************************************
    //**************Set Up ENUM for Grape Family Type**********
    //*********************************************************

    public enum GrapeFamType  // Data Model
    {
        //To Describe Different Families of Grapes
        [Description("Vitis Vinifera")]
        VitisVinifera, //European Family of Grapes [Chardonnay, Merlot, Cab. Sav. etc...]
        [Description("Vitis Riparia")]
        VitisRiparia,  //Rootstock common varieties
        [Description("Vitis Labrusca")]
        VitisLabrusca  //Concord, Niagara, Catawba, Notably 'foxy' flavored grapes
    };

    //*********************************************************
    //*************Set Up ENUM for Wine Type e.g. Table********
    //*********************************************************

    public enum WineType  // Data Model
    {
        Table,         //Wine 12% or less ABV
        Dessert,       //Wine >12% ABV
        Sparkling      //Champagne Style Wine
    };

    //**************************************************************
    //**************** Set Up TTB Wine Classes**********************
    //**************************************************************

    public enum TTBWineClass
    {
        // Some of the coding in this portion of the project refers to data from Title 27 of the Code of Federal Regulations (Alcohol, Tobacco, and Firearms), Part 4 - Labeling and Advertising of Wine - Subpart C - Standards of Identity for Wine - Section 4.21 - referring to nine distinct separate classes of wine.  These include:

        // "Grape Wine", 
        // "Sparkling Grape Wine", 
        // "Carbonated Grape Wine", 
        // "Citrus Wine", 
        // "Fruit Wine", 
        // "Wine From Other Agricultural Products", 
        // "Aperitif Wine", 
        // "Imitiation and Substandard or Other Than Standard Wine",
        // "Retsina Wine" - Wine made from resin ??? Cannabis Wine? 

        //[Description(&quot;The Color of my skin & quot;)]
        //White,
        //[Description(&quot;Bulls like this color & quot;)]
        //Red,
        //[Description(&quot;The color of slime & quot;)]
        //Green


        //[Description(&quot; Grape Wine & quot;)]GrapeWine,                  // The lay person's idea of still wine - Merlot

        [Description("Grape Wine")]
        GrapeWine,
        [Description("Sparkling Grape Wine")]
        SparklingGrapeWine,         //  
        [Description("Carbonated Grape Wine")]
        CarbonatedGrapeWine,
        [Description("Citrus Wine")]
        CitrusWine,                 // Citrus fruit wine (Grapefruits, oranges, etc.)
        [Description("Fruit Wine")]
        FruitWine,                  // Non-citrus Non-fruit Non-grape wine.
        [Description("Wine From Ag Products")]
        WineFromAgProducts,
        [Description("Aperitif Wine")]
        AperitifWine,
        [Description("Imitation Sustandard Wine")]
        ImitationSubstandardWine,
        [Description("Retsina Wine")]
        RetsinaWine                 // Wine made from resin

        // For purpose of project and until further investigation concludes it shall be assumed that no other classes of wines will be approved by the Tax and Trade Bureau to appear in the Code of Federal Regulations (CFR) - United States Code.
    }

    //***********************************************
    //*** Repository ***
    //***********************************************

    public static class Repository
    {

        public static List<GrapeVarietal> GetAllGrapeVarietals()
        {

            using (var context = new WineContext())
            {
                return context.Varietals.ToList();
            }
        }

        public static List<TTBActiveWinePermit> GetAllPermits()
        {

            using (var context = new WineContext())
            {
                return context.TTBActiveWinePermits.ToList();
            }
        }


    }
}

