using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DayCareGuarderia.Models.Entities;

    public class DayCareGuarderiaDataContext : DbContext
    {
        public DayCareGuarderiaDataContext (DbContextOptions<DayCareGuarderiaDataContext> options)
            : base(options)
        {
        }

        public DbSet<Activities> Activities { get; set; } 
        public DbSet<Parent> Parent { get; set; }
}
