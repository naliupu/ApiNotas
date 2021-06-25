using BackEndPreguntas.Domain.Models;
using BackEndPreguntas.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BackEndPreguntas.Commands
{
    public class NotesUpdateCommand : CommandBase
    {
        private static String ParId = "Id";
        private static String ParTitle = "Title";
        private static String ParContent = "Content";
        private static String ParPriority = "Priority";
        private static String ParUpdateDate = "UpdateDate";
        private static String fUpdateTransaction =
            "UPDATE CDCS.notas SET  title = " +
            "    @" + ParTitle + ", " + "content = " +
            "    @" + ParContent + ", " + "dateupdate = " +
            "    @" + ParUpdateDate + ", " + "priority =" +
            "    @" + ParPriority + " WHERE idnotas = " +
            "    @" + ParId + ";";

        public Notas NotasRequest { get; set; }

        public NotesUpdateCommand(DbProviderFactory dbProvider) :
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
                        updateBankPayment.AddParameterWithValue(ParId, this.NotasRequest.Id);
                        updateBankPayment.AddParameterWithValue(ParTitle, this.NotasRequest.Title);
                        updateBankPayment.AddParameterWithValue(ParContent, this.NotasRequest.Content);
                        updateBankPayment.AddParameterWithValue(ParPriority, this.NotasRequest.Priority);
                        updateBankPayment.AddParameterWithValue(ParUpdateDate, DateTime.UtcNow.ToLocalTime());
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
