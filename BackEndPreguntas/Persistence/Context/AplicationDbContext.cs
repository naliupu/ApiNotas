using BackEndPreguntas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndPreguntas.Persistence.Context
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Notas> Notas { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }
    }
}
