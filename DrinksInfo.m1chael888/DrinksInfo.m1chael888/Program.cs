using Microsoft.Extensions.DependencyInjection;
using DrinksInfo.m1chael888.Infratrstructure;
using DrinksInfo.m1chael888.Services;
using DrinksInfo.m1chael888.Views;
using System.Text;
using DrinksInfo.m1chael888.Controllers;

namespace DrinksInfo.m1chael888
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var collection = new ServiceCollection();

            collection.AddScoped<IRouter, Router>();
            collection.AddScoped<DrinksController>();
            collection.AddScoped<IDrinksService, DrinksService>();
            collection.AddScoped <IDrinksView, DrinksView>();

            var provider = collection.BuildServiceProvider();

            var drinksController = provider.GetRequiredService<DrinksController>();
            var router = provider.GetRequiredService<IRouter>();
            router.Route(drinksController);
        }
    }
}