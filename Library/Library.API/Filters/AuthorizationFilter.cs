using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Library.API.Filters
{
    public class AuthorizationFilter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }
            operation.Parameters.Add(new OpenApiParameter
            {
                Name= "Authorization",
                In=ParameterLocation.Header,
                Description="Basic admin:admin",
                Required = false,
                Schema = new OpenApiSchema { Type = "string" }
            });

        }
    }
}