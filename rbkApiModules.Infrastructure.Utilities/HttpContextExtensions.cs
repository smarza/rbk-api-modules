﻿using Microsoft.AspNetCore.Http;

namespace rbkApiModules.Utilities.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUsername(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.User.Identity.Name.ToLower();
        } 

        public static void SetResponseSource(this HttpContext context)
        {
            context.Items.Add("was-cached", true);
        }
    }
}
