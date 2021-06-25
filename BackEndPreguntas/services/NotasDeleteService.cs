using BackEndPreguntas.Commands;
using BackEndPreguntas.Domain.IServices;
using BackEndPreguntas.Domain.Models;
using Npgsql;
using System.Data.Common;

namespace BackEndPreguntas.services
{
    public class NotasDeleteService : INotasDeleteService
	{
		public ServiceResponse Execute(Notas notas)
		{
			ServiceResponse resp = new ServiceResponse();
			DbProviderFactory provider = NpgsqlFactory.Instance;
			NotesDeleteCommand command = new NotesDeleteCommand(provider);
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
