using BackEndPreguntas.Domain.IServices;
using BackEndPreguntas.Domain.Models;
using BackEndPreguntas.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace BackEndPreguntas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
		
        //Servicios de notas
        INotasAddService notasAddService;
        INotasGetService notasGetService;
        INotasUpdateService notasUpdateService;
        INotasDeleteService notasDeleteService;
        INotasSearchDateService notasSearchDateService;
        public NotesController(INotasAddService notasAddService, INotasGetService notasGetService, INotasUpdateService notasUpdateService, INotasDeleteService notasDeleteService, INotasSearchDateService notasSearchDateService)
		{
            this.notasAddService = notasAddService;
            this.notasGetService = notasGetService;
            this.notasUpdateService = notasUpdateService;
            this.notasDeleteService = notasDeleteService;
            this.notasSearchDateService = notasSearchDateService;
        }

        //Obtiene todas las notas registradas
        //[CustomAuthorize]
        [Route("getNotas")]
        [HttpGet]
        [Produces("application/json")]
        public ServiceResponse Get()
        {
            return this.notasGetService.Execute();
        }

        //Modifica las notas
        [CustomAuthorize]
        [Route("updateNotas")]
        [HttpPost]
        [Produces("application/json")]
        public ServiceResponse Update([FromBody] Notas notas)
        {
            return this.notasUpdateService.Execute(notas);
        }

        //Busca una nota por una fecha indicada
        [CustomAuthorize]
        [Route("searchDate")]
        [HttpPost]
        public ServiceResponse Search(Notas notas)
        {
            return this.notasSearchDateService.Execute(notas);
        }

        //Eliminar una nota
        [CustomAuthorize]
        [Route("deleteNotas")]
        [HttpPost]
        [Produces("application/json")]
        public ServiceResponse Delete(Notas notas)
        {
            return this.notasDeleteService.Execute(notas);
        }

        //Agregar una nota
        [CustomAuthorize]
        [Route("addNotas")]
		[HttpPost]
		[Produces("application/json")]
		public ServiceResponse Post([FromBody] Notas notas)
		{
			return this.notasAddService.Execute(notas);
		}
	}
}
