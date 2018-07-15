using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using hateSpeach.Models;
using hateSpeach.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Microsoft.ML.Runtime.LightGBM;

namespace hateSpeach
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            // workaround to ensure LightGbm assembly is loaded
            //new LightGbmArguments();
            MLTraining.LanguageModel = await MLTraining.LanguageTrainAsync();
            MLTraining.SentimentModel = await MLTraining.SentimentTrainAsync();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
