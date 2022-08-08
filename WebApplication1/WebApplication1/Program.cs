using Microsoft.AspNetCore.Builder;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/hello", () => "Hello World!");
            app.Run("http://localhost:1200");
        }
    }
}
