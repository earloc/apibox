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
        private readonly IGreeterSamples oData;

        public GreeterSampleProvider(GraphQLGreeterSamples graphQL, WebApiGreeterSamples webApi, ODataGreeterSamples oData)
        {
            this.graphQL = graphQL ?? throw new ArgumentNullException(nameof(graphQL));
            this.webApi = webApi ?? throw new ArgumentNullException(nameof(webApi));
            this.oData = oData ?? throw new ArgumentNullException(nameof(oData));
        }


        public Func<Task> Select(string stack, string name)
        {
            var samples = stack switch
            {
                "GraphQL" => this.graphQL,
                "WebApi" => this.webApi,
                "OData" => this.oData,
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