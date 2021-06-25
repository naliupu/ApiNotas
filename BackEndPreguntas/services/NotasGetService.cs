using BackEndPreguntas.Commands;
using BackEndPreguntas.Domain.IServices;
using BackEndPreguntas.Domain.Models;
using Newtonsoft.Json;
using Npgsql;
using System.Collections.Generic;
using System.Data.Common;

namespace BackEndPreguntas.services
{
	public class NotasGetService : INotasGetService
	{
		public ServiceResponse Execute()
		{
			ServiceResponse resp = new ServiceResponse();
			DbProviderFactory provider = NpgsqlFactory.Instance;
			NotesGetCommand command = new NotesGetCommand(provider);
			var respCommand = command.Execute();
			if (respCommand.HttpStatusCode == System.Net.HttpStatusCode.OK)
			{
				resp.notas = JsonConvert.DeserializeObject<List<Notas>>(respCommand.Content);
			}
			else
			{
				resp.ErrorMessage = respCommand.ErrorMessage;
				resp.ErrorCode = respCommand.HttpStatusCode.ToString();
			}
			return resp;
		}
	}
}
