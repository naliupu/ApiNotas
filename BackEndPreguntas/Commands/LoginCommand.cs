using BackEndPreguntas.Domain.Models;
using BackEndPreguntas.Models;
using System;
using System.Data.Common;
using System.Net;

namespace BackEndPreguntas.Commands
{
    public class LoginCommand : CommandBase
    {

        private static String ParId = "id";
        private static String ParPassword = "password";
        private static String ParUsername = "username";
        private static String fUpdateTransaction = "SELECT id FROM CDCS.users  WHERE username =" + " @" + ParUsername;

        public Users UsersRequest { get; set; }
        public Int32 Id { get; set; }

        public LoginCommand(DbProviderFactory dbProvider) :
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
                        updateBankPayment.AddParameterWithValue(ParId, this.UsersRequest.id);
                        updateBankPayment.AddParameterWithValue(ParUsername, this.UsersRequest.username);
                        updateBankPayment.AddParameterWithValue(ParPassword, this.UsersRequest.password);
                        updateBankPayment.CommandText = fUpdateTransaction;
                        object id = updateBankPayment.ExecuteScalar();

                        if (id != null)
                        {
                            resp.Id = Convert.ToInt32(id);
                        }

                        if (resp.Id >= 0)
                        {
                            resp.HttpStatusCode = HttpStatusCode.Found;
                        }
                        else
                        {
                            resp.HttpStatusCode = HttpStatusCode.NotFound;
                        }
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
