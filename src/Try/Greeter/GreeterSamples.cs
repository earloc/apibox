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
        private readonly IGreeterSamples graphQL;
        private readonly IGreeterSamples webApi;

        public GreeterSampleProvider(GraphQLGreeterSamples graphQL, WebApiGreeterSamples webApi)
        {
            this.graphQL = graphQL ?? throw new ArgumentNullException(nameof(graphQL));
            this.webApi = webApi ?? throw new ArgumentNullException(nameof(webApi));
        }


        public Func<Task> Select(string stack, string name)
        {
            var samples = stack switch
            {
                "GraphQL" => this.graphQL,
                "WebApi" => this.webApi,
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