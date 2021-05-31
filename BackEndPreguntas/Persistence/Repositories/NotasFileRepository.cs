using BackEndPreguntas.Domain.IRepositories;
using BackEndPreguntas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BackEndPreguntas.Persistence.ContextNotas;

namespace BackEndPreguntas.Persistence.Repositories
{
    public class NotasFileRepository : INotasRepository
    {
        private notasContext _db;
        public NotasFileRepository(notasContext db)
        {
            _db = db;
        }
        public async Task AddNote(Notas notas)
        {
            _db.Add(notas);
            await _db.SaveChangesAsync();
        }


        public async Task UpdateNote(Notas notas)
        {
            _db.Update(notas);
            await _db.SaveChangesAsync();
        }

        public async Task<Notas> BuscarNota(int idNota)
        {
            var nota = await _db.Notas.Where(x => x.Id == idNota).FirstOrDefaultAsync();
            return nota;
        }

        public async Task DeleteNote(Notas notas)
        {
            _db.Entry(notas).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
        }

        public async Task<List<Notas>> GetNote()
        {
            var notas = await _db.Notas.OrderBy(x => x.Priority).ToListAsync();
            return notas;
        }

        public async Task<Notas> SearchByDateNote(DateTime fecha)
        {
            var dateNote = await _db.Notas.Where(x => x.CreationDate == fecha || x.UpdateDate == fecha).FirstOrDefaultAsync();
            return dateNote;
        }
    }
}
