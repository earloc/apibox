/*
using ApiBox.Api.Tests;

using GraphTypesFirstStartup = ApiBox.Api.GraphQLDotNet.GraphTypesFirst.Startup;
*/
using System;
using System.Threading.Tasks;

namespace Try.Greeter
{


    public class GreeterSampleProvider : ISampleProvider
    {
        private readonly GraphQLGreeterSamples graphQL;

        public GreeterSampleProvider(GraphQLGreeterSamples graphQL)
        {
            this.graphQL = graphQL ?? throw new ArgumentNullException(nameof(graphQL));
        }


        public Func<Task> Select(string stack, string name)
        {
            var samples = stack switch
            {
                "GraphQL" => this.graphQL,
                _ => null
            };

            Func<Task> action = (samples, name) switch
            {
                (IGreeterSamples sample, "SayHello") => () => sample.SayHello(),
                _ => () => { Console.WriteLine("sample n/a"); return Task.CompletedTask; }
            };

            return action;
        }
    }
}