using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace REST_API_Example.Middleware
{
    public class AuthenticationCheck
    {
        /*
         static public IApplicationBuilder validateAPIKey(HttpContext context, System.Func<Task> next)
        {
            string authHeader = context.Request.Headers["Authorization"];
            string apiKey = System.Environment.GetEnvironmentVariable("KEY");

            if (string.IsNullOrEmpty(authHeader) || !authHeader.Equals(apiKey))
            {

                Dictionary<string, string> responseBody = new Dictionary<string, string>() {
                        { "error", "true" },
                        { "message", "Invalid or missing API key." }
                    };

                string jsonResponse = JsonConvert.SerializeObject(responseBody);

                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";

                return context.Response.WriteAsync(jsonResponse);
            }

            return next();
        }
         */
    }
}
