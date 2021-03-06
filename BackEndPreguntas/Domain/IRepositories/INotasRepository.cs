using BackEndPreguntas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndPreguntas.Domain.IRepositories
{
    public interface INotasRepository
    {
        Task AddNote(Notas notas);
        Task UpdateNote(Notas notas);
        Task<Notas> BuscarNota(int idNota);
        Task<List<Notas>> BuscarNotaFecha(DateTime fecha);
        Task DeleteNote(Notas notas);
        Task<List<Notas>> GetNote();
        Task<List<Notas>> GetNoteId(int idNotas);
    }
}
