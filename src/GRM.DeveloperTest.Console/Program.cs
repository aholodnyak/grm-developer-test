using System;
using System.Collections.Generic;
using System.IO;
using GRM.DeveloperTest.Core;
using GRM.DeveloperTest.Core.Configuration;
using GRM.DeveloperTest.Core.Models;
using Microsoft.Extensions.Configuration;

namespace GRM.DeveloperTest.Console
{
    internal class Program
    {
        private static readonly ProjectConfiguration Configuration = new ProjectConfiguration();
        private static ApplicationService _applicationService;

        private static void Main(string[] args)
        {
            try
            {
                var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
                configuration.Bind(Configuration);

                _applicationService = new ApplicationService(Configuration);

                System.Console.WriteLine("Data Initialized successfully");
                System.Console.WriteLine("Please enter partner and date (like 'YouTube 1st April 2012'), enter 'exit' for exit");

                while (true)
                {
                    var input = System.Console.ReadLine();
                    if (input != null && input.Equals("exit", StringComparison.OrdinalIgnoreCase)) break;

                    var data = _applicationService.SearchData(input);
                    OutputData(data);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private static void OutputData(List<MusicContract> data)
        {
            System.Console.WriteLine("Artist|Title|Usage|StartDate|EndDate");
            foreach (var musicContract in data) System.Console.WriteLine(musicContract.ToString());
            System.Console.WriteLine();
        }
    }
}