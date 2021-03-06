﻿using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace ApiBox.Api.GraphQLDotNet.GraphTypesFirst
{
    public class ApiBoxSchema : Schema
    {
        public ApiBoxSchema(IServiceProvider services)
            : base(services)
        {
            Query = services.GetRequiredService<ApiBoxQuery>();
        }
    }
}
