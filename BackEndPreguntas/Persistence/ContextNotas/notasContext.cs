using System;
using BackEndPreguntas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEndPreguntas.Persistence.ContextNotas

{
    public partial class notasContext : DbContext
    {
        
        public DbSet<Notas> Notas { get; set; }

        public notasContext(DbContextOptions<notasContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
