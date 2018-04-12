namespace WineEntryProposal.Views.Wine
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TTBActiveWinePermit
    {
        [Key]
        [Column("PERMIT NUMBER")]
        [StringLength(255)]
        public string PERMIT_NUMBER { get; set; }

        [Column("OWNER NAME")]
        [StringLength(255)]
        public string OWNER_NAME { get; set; }

        [Column("OPERATING NAME")]
        [StringLength(255)]
        public string OPERATING_NAME { get; set; }

        [StringLength(255)]
        public string STREET { get; set; }

        [StringLength(255)]
        public string CITY { get; set; }

        [StringLength(255)]
        public string STATE { get; set; }

        public double? ZIP { get; set; }

        public double? ZIP4 { get; set; }

        [StringLength(255)]
        public string COUNTY { get; set; }
    }
}
