using BackEndPreguntas.Domain.IRepositories;
using BackEndPreguntas.Domain.Models;
using BackEndPreguntas.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndPreguntas.Persistence.Repositories
{
    public class NotasRepository: INotasRepository
    {
        private readonly AplicationDbContext _context;
        public NotasRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddNote(Notas notas)
        {
            _context.Add(notas);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateNote(Notas notas)
        {
            _context.Update(notas);
            await _context.SaveChangesAsync();
        }

        public async Task<Notas> BuscarNota(int idNota)
        {
            var nota = await _context.Notas.Where(x => x.Id == idNota).FirstOrDefaultAsync();
            return nota;
        }

        public async Task DeleteNote(Notas notas)
        {
            _context.Entry(notas).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Notas>> GetNote()
        {
            var notas = await _context.Notas.OrderBy(x => x.Priority).ToListAsync();
            return notas;
        }

        public async Task<Notas> SearchByDateNote(DateTime fecha)
        {
            var dateNote = await _context.Notas.Where(x => x.CreationDate == fecha || x.UpdateDate == fecha).FirstOrDefaultAsync();
            return dateNote;
        }
    }
}
