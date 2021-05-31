using BackEndPreguntas.Domain.Models;
using BackEndPreguntas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndPreguntas.Domain.IRepositories;
using BackEndPreguntas.Domain.IServices;

namespace BackEndPreguntas.services
{
    public class NotasService : INotasService
    {
        private readonly INotasRepository _notasRepository;
        public NotasService(INotasRepository notasRepository)
        {
            _notasRepository = notasRepository;
        }

        public async Task AddNote(Notas notas)
        {
            await _notasRepository.AddNote(notas);
        }

        public async Task UpdateNote(Notas notas)
        {
            await _notasRepository.UpdateNote(notas);
        }

        public async Task<Notas> BuscarNota(int idNota)
        {
            return await _notasRepository.BuscarNota(idNota);
        }

        public async Task DeleteNote(Notas notas)
        {
            await _notasRepository.DeleteNote(notas);
        }

        public async Task<List<Notas>> GetNote()
        {
            return await _notasRepository.GetNote();
        }

        public async Task<Notas> SearchByDateNote(DateTime fecha)
        {
            return await _notasRepository.SearchByDateNote(fecha);
        }
    }
}
