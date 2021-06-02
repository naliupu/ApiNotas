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
            notas.CreationDate = DateTime.Today;
            notas.UpdateDate = DateTime.Today;
            await _notasRepository.AddNote(notas);
        }

        public async Task UpdateNote(Notas notas)
        {
            //notas.UpdateDate = DateTime.Today;
            await _notasRepository.UpdateNote(notas);
        }

        public async Task<Notas> BuscarNota(int idNota)
        {
            return await _notasRepository.BuscarNota(idNota);
        }

        public async Task<List<Notas>> BuscarNotaFecha(DateTime fecha)
        {
            return await _notasRepository.BuscarNotaFecha(fecha);
        }

        public async Task DeleteNote(Notas notas)
        {
            await _notasRepository.DeleteNote(notas);
        }

        public async Task<List<Notas>> GetNote()
        {
            return await _notasRepository.GetNote();
        }
    }
}
