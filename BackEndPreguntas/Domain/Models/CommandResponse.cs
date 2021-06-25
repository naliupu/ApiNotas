using System;

namespace BackEndPreguntas.Models
{
	public class CommandResponse
	{
		/// <summary>
		/// Cóodigo de error
		/// </summary>
		public Int32 ErrorCode { get; set; }
		/// <summary>
		/// Mensaje del error
		/// </summary>
		public String ErrorMessage { get; set; }
		/// <summary>
		/// Información obtenida
		/// </summary>
		public String Content { get; set; }

		public Int32 Id { get; set; }

		public System.Net.HttpStatusCode HttpStatusCode { get; set; }

	}
}
