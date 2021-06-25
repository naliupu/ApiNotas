using BackEndPreguntas.Commands;
using BackEndPreguntas.Domain.IServices;
using BackEndPreguntas.Domain.Models;
using Newtonsoft.Json;
using Npgsql;
using System.Collections.Generic;
using System.Data.Common;

namespace BackEndPreguntas.services
{
	public class NotasSearchDateService : INotasSearchDateService
	{
		public ServiceResponse Execute(Notas notas)
		{
			ServiceResponse resp = new ServiceResponse();
			DbProviderFactory provider = NpgsqlFactory.Instance;
			NotesSearchDateCommand command = new NotesSearchDateCommand(provider);
			command.NotasRequest = notas;
			var respCommand = command.Execute();
			if (respCommand.HttpStatusCode != System.Net.HttpStatusCode.OK)
			{
				resp.ErrorMessage = respCommand.ErrorMessage;
				resp.ErrorCode = respCommand.HttpStatusCode.ToString();
            }
            else
            {
				resp.notas = JsonConvert.DeserializeObject<List<Notas>>(respCommand.Content);
			}
			return resp;
		}
	}
}
