using BackEndPreguntas.Domain.Models;
using BackEndPreguntas.Models;
using System;
using System.Data.Common;
using System.Net;

namespace BackEndPreguntas.Commands
{
    public class LoginCommand : CommandBase
    {

        //private static String ParId = "id";
        private static String ParPassword = "password";
        private static String ParUsername = "username";
        private static String fUpdateTransaction = "SELECT id  from cdcs.users  WHERE username =" + " @" + ParUsername + " AND password =" + " @" + ParPassword + ";";


        public Users UsersRequest { get; set; }
        //public CommandResponse resp { get; set; }

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
                        //updateBankPayment.AddParameterWithValue(ParId, this.UsersRequest.id);
                        updateBankPayment.AddParameterWithValue(ParUsername, this.UsersRequest.username);
                        updateBankPayment.AddParameterWithValue(ParPassword, this.UsersRequest.password);
                        updateBankPayment.CommandText = fUpdateTransaction;
                        object idUpdateBankPayment = updateBankPayment.ExecuteScalar();

                        if (idUpdateBankPayment != null)
                        {
                            //resp.Id = Convert.ToInt32(idUpdateBankPayment);
                            resp.Id = (int)idUpdateBankPayment;
                            resp.HttpStatusCode = HttpStatusCode.Found;
                        }

                        if (idUpdateBankPayment == null)
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
