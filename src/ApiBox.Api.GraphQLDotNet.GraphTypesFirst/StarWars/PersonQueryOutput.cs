﻿using ApiBox.StarWars;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace ApiBox.Api.GraphQLDotNet.GraphTypesFirst.StarWars
{
    public class PersonQueryOutput : ObjectGraphType<IEnumerable<Person>>
    {
        public PersonQueryOutput()
        {
            Field<IntGraphType>("Count", resolve: context => context.Source.Count());
            Field<ListGraphType<PersonOutput>>("Persons", resolve: context => context.Source);
        }
    }
}
