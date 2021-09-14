using Microsoft.Extensions.DependencyInjection;
using System;
using WordCounter.Client.Services;
using WordCounter.Client.Services.Contracts;

namespace WordCounter.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureDI();

            var wcs = serviceProvider.GetService<IWordCounterService>();

            Prompt(wcs);
        }

        // Dependency Injection Configuration
        static ServiceProvider ConfigureDI()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddHttpClient<IHttpService, HttpService>();

            return serviceCollection
                    .AddSingleton<IWordCounterService, WordCounterService>()
                    .AddSingleton<IHttpService, HttpService>()
                    .BuildServiceProvider();
        }

        static void Prompt(IWordCounterService wcs)
        {
            Console.WriteLine("You are using the Word Counter App - App for counting words in samples of text");
            Console.WriteLine("Please select the source of your text - Options are File(f), Database(d) or Direct console input(c):");
            string input = Console.ReadLine().ToLower();

            long count;
            switch (input)
            {
                case "f":
                    try
                    {
                        count = wcs.ProcessFile();
                        Console.WriteLine($"Your word count is: {count}");
                    } catch(Exception ex)
                    {
                        Console.WriteLine("An error occured");
                        Console.WriteLine(ex.Message);
                    }
                    
                    break;
                case "d":
                    try
                    {
                        count = wcs.ProcessDbEntry();
                        Console.WriteLine($"Your word count is: {count}");
                    } catch (Exception ex)
                    {
                        Console.WriteLine("An error occured");
                        Console.WriteLine(ex.Message);
                    }

                    break;
                case "c":
                    try
                    {
                        count = wcs.ProcessUserInput();
                        Console.WriteLine($"Your word count is: {count}");
                    } catch (Exception ex)
                    {
                        Console.WriteLine("An error occured");
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Incorrect input. Existing program.");
                    break;
            }
        }

    }
}
