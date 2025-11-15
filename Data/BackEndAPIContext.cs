using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class BackEndAPIContext : DbContext
    {
        public BackEndAPIContext (DbContextOptions<BackEndAPIContext> options)
            : base(options)
        {
        }

        public DbSet<api.Models.LegalEntity> LegalEntity { get; set; } = default!;
        public DbSet<api.Models.NaturalPerson> NaturalPerson { get; set; } = default!;
    }
}
