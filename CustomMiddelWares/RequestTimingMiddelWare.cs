using System.Diagnostics;

namespace MVC01.CustomMiddelWares
{
    public class RequestTimingMiddelWare
    {
        private readonly RequestDelegate next;
        public RequestTimingMiddelWare(RequestDelegate next) {
            this.next  = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            //Next
            await next(context);
            watch.Stop();
            Console.WriteLine($"[[{context.Request.Path}]] :: {watch.ElapsedMilliseconds} ms ");
        }
    }
}
