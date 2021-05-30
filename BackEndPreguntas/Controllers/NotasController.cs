 using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEndPreguntas.Domain.IServices;
using BackEndPreguntas.Domain.Models;

namespace BackEndPreguntas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly INotasService _notasService;
        public NotasController(INotasService notasService)
        {
            _notasService = notasService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody] Notas notas) {
            try
            {
                notas.CreationDate = DateTime.Now;
                await _notasService.AddNote(notas);
                return Ok(new { message = "Nota registrada con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNote([FromBody] Notas notas)
        {
            try
            {
                notas.UpdateDate = DateTime.Now;
                await _notasService.UpdateNote(notas);
                return Ok(new { message = "Nota modificada con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Route("Notas")]
        [HttpGet()]
        public async Task<IActionResult> GetNote()
        {
            try
            {
                var notas = await _notasService.GetNote();
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<IActionResult> SearchByDateNote(DateTime fecha)
        {
            try
            {
                var searhFecha = await _notasService.SearchByDateNote(fecha);
                return Ok(searhFecha);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{idNotas}")]
        public async Task<IActionResult> DeleteNote(int idNotas)
        {
            try
            {
                var nota = await _notasService.BuscarNota(idNotas);
                if(nota == null)
                {
                    return BadRequest(new { message = "No se encontro la nota" });
                }
                await _notasService.DeleteNote(nota);
                return Ok(new { message = "La nota fue eliminada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}