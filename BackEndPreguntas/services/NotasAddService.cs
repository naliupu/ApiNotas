using BackEndPreguntas.Commands;
using BackEndPreguntas.Domain.IServices;
using BackEndPreguntas.Domain.Models;
using Npgsql;
using System.Data.Common;

namespace BackEndPreguntas.services
{
    public class NotasAddService : INotasAddService
    {
		public ServiceResponse Execute(Notas notas)
		{
			ServiceResponse resp = new ServiceResponse();
			DbProviderFactory provider = NpgsqlFactory.Instance;
			NotesAddCommand command = new NotesAddCommand(provider);
			command.NotasRequest = notas;
			var respCommand = command.Execute();
			if (respCommand.HttpStatusCode != System.Net.HttpStatusCode.OK)
			{
				resp.ErrorMessage = respCommand.ErrorMessage;
				resp.ErrorCode = respCommand.HttpStatusCode.ToString();
			}
			return resp;
		}
	}
}
