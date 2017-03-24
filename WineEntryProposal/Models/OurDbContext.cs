using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WineEntryProposal.Models
{
    public class OurDbContext : DbContext
    {
    public DbSet<Gallery> gallery { get; set; }
    }
}