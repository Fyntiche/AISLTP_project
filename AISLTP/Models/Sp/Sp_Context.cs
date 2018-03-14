using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AISLTP.Models.Sp
{
    public class Sp_Context : DbContext
    {
        public Sp_Context() : base( "DefaultConnection" ) { }
        public DbSet<Sp_court> Sp_courts { get; set; }
    }
}