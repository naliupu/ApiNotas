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

        [Route("Registrar")]
        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody] Notas notas)
        {
            try
            {
                notas.CreationDate = DateTime.Today;
                notas.UpdateDate = DateTime.Today;
                await _notasService.AddNote(notas);
                return Ok(new { message = "Nota registrada con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public async Task<IActionResult> UpdateNote([FromBody] int idNotas)
        //[Route("Modificar")]
        [HttpPut("Modificar/{idNotas}")]
        public async Task<IActionResult> UpdateNote(int idNotas,Notas notas)
        {
            try
            {

                //var nota = _notasService.BuscarNota(notas.Id);
                //if (nota == null)
                //{
                //    return BadRequest(new { message = "No se encontro la nota", nota });
                //}
                //notas.CreationDate = nota.CreationDate;
                //notas.UpdateDate = DateTime.Today;
                if (idNotas == notas.Id) {
                    await _notasService.UpdateNote(notas);
                    return Ok(new { message = "Nota modificada con exito!", notas });
                }
                else
                {
                    return NotFound();

                }

                //return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Listar")]
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

        [HttpGet("ListarFecha/{fecha}")]
        public async Task<IActionResult> BuscarNotaFecha(DateTime fecha)
        {
            try
            {
                var searhFecha = await _notasService.BuscarNotaFecha(fecha);
                //if (searhFecha == null)
                //{
                //    return BadRequest(new { message = "No se encontro la nota" });
                //}
                return Ok(searhFecha);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Eliminar/{idNotas}")]
        public async Task<IActionResult> DeleteNote(int idNotas)
        {
            try
            {
                var nota = await _notasService.BuscarNota(idNotas);
                if (nota == null)
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