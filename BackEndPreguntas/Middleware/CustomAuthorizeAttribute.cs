using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace BackEndPreguntas.Middleware
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			try
			{
				Int32 userId = (Int32)context.HttpContext.Items["Users"];
				if (userId == 0 || context == null)
				{
					// not logged in
					context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
				}
			}
			catch (Exception e)
			{

			}
			
		}
	}
}
