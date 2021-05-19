using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_MAUREL_CHEVILLARD.Models;

namespace ProjetFinal_MAUREL_CHEVILLARD.Data
{
    public class ProjetFinal_MAUREL_CHEVILLARDContext : DbContext
    {
        public ProjetFinal_MAUREL_CHEVILLARDContext (DbContextOptions<ProjetFinal_MAUREL_CHEVILLARDContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetFinal_MAUREL_CHEVILLARD.Models.Freelance> Freelance { get; set; }
    }
}
