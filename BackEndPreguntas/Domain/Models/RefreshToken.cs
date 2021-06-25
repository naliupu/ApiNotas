using Newtonsoft.Json;
using System;

namespace BackEndPreguntas.Domain.Models
{
    public class RefreshToken
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("tokenString")]

        public string TokenString { get; set; }

        [JsonProperty("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
}
