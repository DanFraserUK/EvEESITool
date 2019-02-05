using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JWT;
using JWT.Builder;
using JWT.Algorithms;
using JWT.Serializers;
using System.Net.Http;

namespace EvEESITool
{
	public class JWT
	{
		// https://esi.evetech.net/

		/// <summary>
		/// JWT.net
		/// </summary>
		/// <param name="secret"></param>
		/// <returns></returns>
		public static bool DecodeToken(string token, string secret, out string jsonResult)
		{
			//string jwkUrl = "https://login.eveonline.com/oauth/jwks";
			bool successful = false;
			jsonResult = "";
			try
			{
				jsonResult = new JwtBuilder()
					.WithSecret(secret)
					.MustVerifySignature()
					.Decode(token);
				successful = true;
			}
			catch (TokenExpiredException)
			{
				Console.WriteLine("Token has expired");
			}
			catch (SignatureVerificationException)
			{
				Console.WriteLine("Token has invalid signature");
			}
			return successful;
		}

		/// <summary>
		/// JWT.net
		/// </summary>
		/// <param name="secret"></param>
		/// <returns></returns>
		public static string CreateToken(string secret)
		{
			return new JwtBuilder()
					  .WithAlgorithm(new HMACSHA256Algorithm())
					  .WithSecret(secret)
					  .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(20).ToUnixTimeSeconds())
					  .AddClaim("claim2", "claim2-value")
					  .Build();
		}

		/// <summary>
		/// System.IdentityModel.Tokens.Jwt
		/// </summary>
		/// <param name="encodedJwt"></param>
		/// <param name="base64EncodedSecret"></param>
		/// <param name="validAudience"></param>
		/// <param name="validIssuer"></param>
		//public static void ValidateJwtWithHs256(String encodedJwt, String base64EncodedSecret, String validAudience, String validIssuer)
		//{
		//	var tokenValidationParameters = new TokenValidationParameters();
		//	//tokenValidationParameters.IssuerSigningKey= new bin
		//	tokenValidationParameters.IssuerSigningKey = new BinarySecretSecurityToken(Base64UrlEncoder.DecodeBytes(base64EncodedSecret));
		//	tokenValidationParameters.ValidIssuer = validIssuer;
		//	tokenValidationParameters.ValidAudience = validAudience;
		//	new JwtSecurityTokenHandler().ValidateToken(encodedJwt, tokenValidationParameters, out SecurityToken securityToken);
		//}

		public class Token
		{
			[JsonProperty("scp")]
			public string[] Scopes { get; set; }
			/// <summary>
			/// Suspected best name
			/// </summary>
			[JsonProperty("jti")]
			public string JsonTokenID { get; set; }
			[JsonProperty("kid")]
			public string KeyID { get; set; }
			[JsonProperty("sub")]
			public string Subscriber { get; set; }
			[JsonProperty("azp")]
			public string AZP { get; set; }
			[JsonProperty("name")]
			public string Name { get; set; }
			[JsonProperty("owner")]
			public string Owner { get; set; }
			[JsonProperty("exp")]
			public int Expires { get; set; }
			[JsonProperty("iss")]
			public string Issuer { get; set; }
		}
	}
}
