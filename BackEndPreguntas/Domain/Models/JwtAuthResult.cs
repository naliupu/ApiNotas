using Newtonsoft.Json;

namespace BackEndPreguntas.Domain.Models
{
    public class JwtAuthResult
    {
		[JsonProperty("accessToken")]
		public string AccessToken { get; set; }

		//[JsonPropertyName("refreshToken")]
		[JsonProperty("refreshToken")]
		public RefreshToken RefreshToken { get; set; }
	}
}
