namespace WineEntryProposal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TTBActiveWinePermitsOlder : DbContext
    {
        public TTBActiveWinePermitsOlder()
            : base("name=TTBActiveWinePermits")
        {
        }

        public virtual DbSet<TTBActiveWinePermitModel> TTBActiveWinePermits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
