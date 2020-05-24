/*
using ApiBox.Api.Tests;

using GraphTypesFirstStartup = ApiBox.Api.GraphQLDotNet.GraphTypesFirst.Startup;
*/
using System;
using System.Threading.Tasks;

namespace Try
{
    internal interface ISampleProvider
    {
        Func<Task> Select(string stack, string name);
    }
}