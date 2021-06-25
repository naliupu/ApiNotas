using BackEndPreguntas.Domain.Models;
using BackEndPreguntas.Models;
using System;
using System.Data;
using System.Data.Common;
using System.Net;

namespace BackEndPreguntas.Commands
{
    public class NotesDeleteCommand : CommandBase
    {
        private static String fUpdateTransaction = "DELETE FROM CDCS.notas WHERE idNotas = @Id";
        public NotesDeleteCommand(DbProviderFactory dbProvider) :
            base(dbProvider)
        {
            this.RDSProvider = dbProvider;
        }

        public Notas NotasRequest { get; set; }


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
                        updateBankPayment.AddParameterWithValue("@id", SqlDbType.Int).Value = this.NotasRequest.Id;
                        updateBankPayment.ExecuteNonQuery();
                        resp.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                if (String.IsNullOrEmpty(resp.Content) || resp.Content == "[]")
                {
                    resp.HttpStatusCode = HttpStatusCode.OK;
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
