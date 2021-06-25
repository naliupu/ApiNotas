using BackEndPreguntas.Domain.Models;
using BackEndPreguntas.Models;
using System;
using System.Data.Common;
using System.Net;

namespace BackEndPreguntas.Commands
{
    public class NotesSearchDateCommand : CommandBase
    {
        private static String ParUpdateDate = "updatedate";
        private static String fUpdateTransaction = "SELECT * FROM CDCS.notas WHERE CAST(dateupdate AS DATE) = @" + ParUpdateDate + ";";
        public NotesSearchDateCommand(DbProviderFactory dbProvider) :
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
                        updateBankPayment.AddParameterWithValue(ParUpdateDate, this.NotasRequest.UpdateDate.Date);


                        updateBankPayment.CommandText = fUpdateTransaction;

                        updateBankPayment.ExecuteNonQuery();

                        updateBankPayment.Prepare();
                        using (DbDataReader dataReader = updateBankPayment.ExecuteReader())
                        {
                            resp.Content = dataReader.ToJson();
                        }
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
