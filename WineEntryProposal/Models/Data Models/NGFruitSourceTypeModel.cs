using System.ComponentModel.DataAnnotations;

namespace WineEntryProposal.Models.Data_Models
{
    public class NGFruitSourceTypeModel  // Data Model
    {
        public int Id { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        //Brix § 151.91 Brix values of unconcentrated natural fruit juices.
        //The following values have been determined to be the average Brix values of unconcentrated natural fruit juices in the trade and commerce of the United States, for the purposes of the provisions of the Additional U.S.Notes to Chapter 20, Harmonized Tariff Schedule of the United States(HTSUS) ( 19 U.S.C. 1202), and will be used in determining the dutiable quantity of imports of concentrated fruit juices, using the procedure set forth in Additional U.S.Note 2, Chapter 20, HTSUS:

        [Range(0.0, 100.0)]
        public double Brix { get; set; }
    }
}
