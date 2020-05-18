using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ApiBox.Api.GraphQLDotNet
{
    public interface IDependency<out T>
    {
        T Instance { get; }
    }

    public class HttpContextDependency<T> : IDependency<T>
    {
        private readonly IHttpContextAccessor accessor;
        public HttpContextDependency(IHttpContextAccessor accessor) => this.accessor = accessor;

        public T Instance { get => accessor.HttpContext.RequestServices.GetRequiredService<T>(); }
    }
}
