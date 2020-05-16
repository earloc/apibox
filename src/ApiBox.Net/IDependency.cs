
using GraphQL.Utilities;
using Microsoft.AspNetCore.Http;

namespace ApiBox.Net
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
