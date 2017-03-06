﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    public class WineAddViewModel
    {
        public Wine TheWine { get; set; }
        public List<GrapeVarietal> VarietalsToChooseFrom { get; set; }
        public string SelectedVarietalId { get; set; }
        public TTBWineClass TheWineClass { get; set; }
    }

    public class WineRemoveViewModel
    {
        public Wine TheWine { get; set; }
        public List<GrapeVarietal> VarietalsToChooseFrom { get; set; }
        public string SelectedVarietalId { get; set; }
        public TTBWineClass TheWineClass { get; set; }
    }

    public class Wine
    {
        public string Name { get; set; }
        public WineType TheWineType { get; set; }
        public GrapeVarietal TheVarietal { get; set; }
        public TTBWineClass TheTTBWineClass { get; set; }
    }
    
    public class GrapeVarietal
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class NGFruitSourceType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Brix § 151.91 Brix values of unconcentrated natural fruit juices.
        //The following values have been determined to be the average Brix values of unconcentrated natural fruit juices in the trade and commerce of the United States, for the purposes of the provisions of the Additional U.S.Notes to Chapter 20, Harmonized Tariff Schedule of the United States(HTSUS) ( 19 U.S.C. 1202), and will be used in determining the dutiable quantity of imports of concentrated fruit juices, using the procedure set forth in Additional U.S.Note 2, Chapter 20, HTSUS:

        public double Brix { get; set; }
    }

    public enum WineType
    {
        Table,
        Dessert,
        Sparkling
    };

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

        GrapeWine,                  // The lay person's idea of still wine - Merlot
        SparklingGrapeWine,         //  
        CarbonatedGrapeWine,
        CitrusWine,                 // Citrus fruit wine (Grapefruits, oranges, etc.)
        FruitWine,                  // Non-citrus Non-fruit Non-grape wine.
        WineFromAgProducts,
        AperitifWine,
        ImitationSubstandardWine,
        RetsinaWine                 // Wine made from resin

        // For purpose of project and until further investigation concludes it shall be assumed that no other classes of wines will be approved by the Tax and Trade Bureau to appear in the Code of Federal Regulations (CFR) - United States Code.

    }

    public static class Repository
    {
        public static List<GrapeVarietal> GetAllGrapeVarietals()
        {
            return new List<GrapeVarietal>()
            {
                new GrapeVarietal() { Id=1, Name="Vidal Blanc" },
                new GrapeVarietal() { Id=2, Name="Concord" },
                new GrapeVarietal() { Id=3, Name="Pinot Noir" },
                new GrapeVarietal() { Id=4, Name="Pinot Grigio" },
                new GrapeVarietal() { Id=5, Name="Niagara" },
                new GrapeVarietal() { Id=6, Name="Catawba" },
                new GrapeVarietal() { Id=7, Name="Steuben" },
                new GrapeVarietal() { Id=8, Name="Chambourcin" },
                new GrapeVarietal() { Id=9, Name="Vignoles" },
                new GrapeVarietal() { Id=10, Name="Merlot" },
                new GrapeVarietal() { Id=11, Name="Cabernet Sauvignon" },
                new GrapeVarietal() { Id=12, Name="Sauvignon Blanc" },
                new GrapeVarietal() { Id=13, Name="Jupiter" },
                new GrapeVarietal() { Id=14, Name="Vanessa" },
                new GrapeVarietal() { Id=15, Name="Canidice" },
                new GrapeVarietal() { Id=16, Name="Norton" },
                new GrapeVarietal() { Id=17, Name="Malbec" },
                new GrapeVarietal() { Id=18, Name="Chambourcin" },
                new GrapeVarietal() { Id=19, Name="Chardonel" },
                new GrapeVarietal() { Id=20, Name="Chardonnay" },
                new GrapeVarietal() { Id=21, Name="Traminette" },
                new GrapeVarietal() { Id=22, Name="Seyval Blanc" },
                new GrapeVarietal() { Id=23, Name="Gewürztraminer" },
                new GrapeVarietal() { Id=24, Name="Marechal Foch" }
            };
        }


        //******************************************************************

        public static List<NGFruitSourceType> GetAllNGFruitSource()
        {
            return new List<NGFruitSourceType>()
            {
                new NGFruitSourceType() { Id=20, Name="Apple", Brix=13.3 },
                new NGFruitSourceType() { Id=21, Name="Apricot", Brix = 14.3 },
                new NGFruitSourceType() { Id=22, Name="Bilberry", Brix = 13.4 },
                new NGFruitSourceType() { Id=23, Name="Whortleberry", Brix = 13.4 },
                new NGFruitSourceType() { Id=24, Name="Vaccinium", Brix = 13.4 },
                new NGFruitSourceType() { Id=25, Name="Myrtillium", Brix = 13.4 },
                new NGFruitSourceType() { Id=26, Name="Black Currant", Brix = 15.0 },
                new NGFruitSourceType() { Id=27, Name="Blackberry", Brix = 10.0 },
                new NGFruitSourceType() { Id=28, Name="Black Raspberry", Brix = 11.1 },
                new NGFruitSourceType() { Id=29, Name="Blueberry", Brix = 14.1 },
                new NGFruitSourceType() { Id=30, Name="Boysenberry", Brix = 10.0 },
                new NGFruitSourceType() { Id=31, Name="Carob", Brix = 40.0 },
                new NGFruitSourceType() { Id=32, Name="Cherry", Brix = 14.3 },
                new NGFruitSourceType() { Id=33, Name="Crabapple", Brix = 15.4 },
                new NGFruitSourceType() { Id=34, Name="Cranberry", Brix = 10.5 },
                new NGFruitSourceType() { Id=35, Name="Date", Brix = 18.5 },
                new NGFruitSourceType() { Id=36, Name="Dewberry", Brix = 10.0 },
                new NGFruitSourceType() { Id=37, Name="Elderberry", Brix = 11.0 },
                new NGFruitSourceType() { Id=38, Name="Fig", Brix = 18.2 },
                new NGFruitSourceType() { Id=39, Name="Grape (Vitis Vinifera)", Brix = 21.5 },
                new NGFruitSourceType() { Id=40, Name="Grape (Slipskin Varieties)", Brix = 16.0 },
                new NGFruitSourceType() { Id=41, Name="Grapefruit", Brix = 10.2 },
                new NGFruitSourceType() { Id=42, Name="Guava", Brix = 7.7 },
                new NGFruitSourceType() { Id=43, Name="Lemon", Brix = 8.9 },
                new NGFruitSourceType() { Id=44, Name="Lime", Brix = 10.0 },
                new NGFruitSourceType() { Id=45, Name="Loganberry", Brix = 10.5 },
                new NGFruitSourceType() { Id=46, Name="Mango", Brix = 17.0 },
                new NGFruitSourceType() { Id=47, Name="Naranjilla", Brix = 10.5 },
                new NGFruitSourceType() { Id=48, Name="Orange", Brix = 11.8 },
                new NGFruitSourceType() { Id=49, Name="Papaya", Brix = 10.2 },
                new NGFruitSourceType() { Id=50, Name="Passion Fruit", Brix = 15.3 },
                new NGFruitSourceType() { Id=51, Name="Peach", Brix = 11.8 },
                new NGFruitSourceType() { Id=52, Name="Pear", Brix = 15.4 },
                new NGFruitSourceType() { Id=53, Name="Pineapple", Brix = 14.3 },
                new NGFruitSourceType() { Id=54, Name="Plum", Brix = 14.3 },
                new NGFruitSourceType() { Id=55, Name="Pomegranate", Brix = 18.2 },
                new NGFruitSourceType() { Id=56, Name="Prune", Brix = 18.5 },
                new NGFruitSourceType() { Id=57, Name="Quince", Brix = 13.3 },
                new NGFruitSourceType() { Id=58, Name="Raisin", Brix = 18.5 },
                new NGFruitSourceType() { Id=59, Name="Red Raspberry", Brix = 10.5 },
                new NGFruitSourceType() { Id=60, Name="Red Currant", Brix = 10.5 },
                new NGFruitSourceType() { Id=61, Name="Soursop", Brix = 16.0 },
                new NGFruitSourceType() { Id=62, Name="Guanabana", Brix = 16.0 },
                new NGFruitSourceType() { Id=63, Name="Annono Muricata", Brix = 16.0 },
                new NGFruitSourceType() { Id=64, Name="Strawberry", Brix = 8.0 },
                new NGFruitSourceType() { Id=65, Name="Tamarind", Brix = 55.0 },
                new NGFruitSourceType() { Id=66, Name="Tangerine", Brix = 11.5 },
                new NGFruitSourceType() { Id=67, Name="Youngberry", Brix = 10.0 }
            };
        }
    }
}