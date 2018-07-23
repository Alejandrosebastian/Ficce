using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FICCE.Models;

namespace FICCE.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<FICCE.Models.Empleado> Empleado { get; set; }

        public DbSet<FICCE.Models.Estantes> Estantes { get; set; }

        public DbSet<FICCE.Models.Compra> Compra { get; set; }

        public DbSet<FICCE.Models.Edificio> Edificio { get; set; }

        public DbSet<FICCE.Models.Evento> Evento { get; set; }

        public DbSet<FICCE.Models.Planta> Planta { get; set; }
    }
}
