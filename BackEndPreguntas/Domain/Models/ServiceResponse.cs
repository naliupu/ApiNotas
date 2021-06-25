using System;
using System.Collections.Generic;

namespace BackEndPreguntas.Domain.Models
{
	/// <summary>
	/// Respuesta del servicio
	/// </summary>
	public class ServiceResponse
	{
		/// <summary>
		/// Cóodigo de error
		/// </summary>
		public String ErrorCode { get; set; }
		/// <summary>
		/// Mensaje del error
		/// </summary>
		public String ErrorMessage { get; set; }
		/// <summary>
		/// Datos de la nota, si va nulo ocurrió un error
		/// </summary>
		public List<Notas> notas { get; set; }
	}
}