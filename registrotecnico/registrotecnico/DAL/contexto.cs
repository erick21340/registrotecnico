using Microsoft.EntityFrameworkCore;
using registrotecnico.Models;
using System.Diagnostics.Metrics;

namespace registrotecnico.DAL
{
   
    
        public class Contexto : DbContext
        {
            

            public Contexto(DbContextOptions<Contexto> options) 
            : base(options) { }
           public DbSet<tecnicos> tecnicos { get; set; }

    }
}
