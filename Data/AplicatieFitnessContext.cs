using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplicatieFitness.Models;

namespace AplicatieFitness.Data
{
    public class AplicatieFitnessContext : DbContext
    {
        public AplicatieFitnessContext (DbContextOptions<AplicatieFitnessContext> options)
            : base(options)
        {
        }

        public DbSet<AplicatieFitness.Models.Membru> Membru { get; set; } = default!;
        public DbSet<AplicatieFitness.Models.Antrenor> Antrenor { get; set; } = default!;
        public DbSet<AplicatieFitness.Models.Abonament> Abonament { get; set; } = default!;
    }
}
