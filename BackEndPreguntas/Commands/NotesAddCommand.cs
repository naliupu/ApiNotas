using BackEndPreguntas.Domain.Models;
using BackEndPreguntas.Models;
using System;
using System.Data.Common;
using System.Net;

namespace BackEndPreguntas.Commands
{
    public class NotesAddCommand : CommandBase
    {
        private static String ParTitle = "title";
        private static String ParContent = "content";
        private static String ParPriority = "priority";
        private static String ParUpdateDate = "updatedate";
        private static String ParCreationDate = "creationdate";
        private static String fUpdateTransaction =
            "INSERT INTO CDCS.notas (title, content, priority, dateupdate, datecreation) " +
            " VALUES (" +
            "	@" + ParTitle + ", " +
            "	@" + ParContent + ", " +
            "	@" + ParPriority + ", " +
            "	@" + ParUpdateDate + ", " +
            "	@" + ParCreationDate + ");";

        public Notas NotasRequest { get; set; }

        public NotesAddCommand(DbProviderFactory dbProvider) :
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
                        updateBankPayment.AddParameterWithValue(ParTitle, this.NotasRequest.Title);
                        updateBankPayment.AddParameterWithValue(ParContent, this.NotasRequest.Content);
                        updateBankPayment.AddParameterWithValue(ParPriority, this.NotasRequest.Priority);
                        updateBankPayment.AddParameterWithValue(ParUpdateDate, DateTime.UtcNow.ToLocalTime());
                        updateBankPayment.AddParameterWithValue(ParCreationDate, DateTime.UtcNow.ToLocalTime());
                        updateBankPayment.ExecuteNonQuery();
                        resp.HttpStatusCode = HttpStatusCode.OK;
                    }
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
