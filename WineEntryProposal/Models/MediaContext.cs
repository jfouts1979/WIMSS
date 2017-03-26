using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WineEntryProposal.Models
{
    public class MediaContext : DbContext
    {
    public DbSet<Gallery> gallery { get; set; }
    }
}