using System;

namespace BackEndPreguntas.Domain.Models
{
    public class AuthenticateResponse
    {
		public Int32 id { get; set; }
		public String name { get; set; }
		public String lastname { get; set; }
		public String username { get; set; }
		public String token { get; set; }
		public String refreshToken { get; set; }

		public AuthenticateResponse(Users users, String token, String refreshToken)
		{
			this.id = users.id;
			this.name = users.name;
			this.lastname = users.lastname;
			this.username = users.username;
			this.token = token;
			this.refreshToken = refreshToken;
		}
	}
}
