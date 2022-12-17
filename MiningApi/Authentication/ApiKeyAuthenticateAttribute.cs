﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace MiningApi.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthenticateAttribute : Attribute, IAsyncActionFilter
    {
        private const string API_KEY_NAME = "Client-Authentication-Key";
        private const string API_KEY_VALUE = "46F9FB60-9D7E-4B27-85A4-02E22960FF2A"; // In this example the key is hardcoded, but it should be stored in a file or a database. Also, each client should have its own unique key.

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // First, check if the header is provided
            if (!context.HttpContext.Request.Headers.TryGetValue(API_KEY_NAME, out var providedAuthenticationKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Content = "No authentication header (using ApiKeyAuthenticateAttribute)"
                };
                return;
            }

            // Next, check if the key is correct
            if (!API_KEY_VALUE.Equals(providedAuthenticationKey, StringComparison.InvariantCultureIgnoreCase))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Content = "Invalid authentication key (using ApiKeyAuthenticateAttribute)"
                };
                return;
            }


            await next();
        }
    }
}