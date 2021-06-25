using BackEndPreguntas.Models;
using System;
using System.Data.Common;
using System.Net;

namespace BackEndPreguntas.Commands
{
	public class NotesGetCommand : CommandBase
	{
		private static String fUpdateTransaction = "SELECT * FROM CDCS.notas ORDER BY priority";
		public NotesGetCommand(DbProviderFactory dbProvider) :
			base(dbProvider)
		{
			this.RDSProvider = dbProvider;
		}
		public override CommandResponse Execute()
		{
			CommandResponse resp = new CommandResponse();

			try
			{
				using (DbConnection connection = this.RDSProvider.CreateConnection())
				{
					connection.ConnectionString = this.ConnectionString;
					connection.Open();
					using (DbCommand updateBankPayment = connection.CreateCommand())
					{
						updateBankPayment.CommandText = fUpdateTransaction;

						updateBankPayment.Prepare();
						using (DbDataReader dataReader = updateBankPayment.ExecuteReader())
						{
							resp.Content = dataReader.ToJson();
						}
					}
				}
				if (String.IsNullOrEmpty(resp.Content) || resp.Content == "[]")
				{
					resp.HttpStatusCode = HttpStatusCode.NotFound;
				}
				else
				{
					resp.HttpStatusCode = HttpStatusCode.OK;
				}

			}
			catch (Exception e)
			{
				resp.ErrorMessage = e.Message;
				resp.HttpStatusCode = HttpStatusCode.InternalServerError;
			}
			return resp;
		}
	}
}
