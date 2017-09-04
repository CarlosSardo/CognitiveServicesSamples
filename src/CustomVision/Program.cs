using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomVision.RefitRestService;
using Newtonsoft.Json;
using Refit;

namespace CustomVision
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            string imageUrl = args[0];
            var data = new Dictionary<string, object> { { "url", imageUrl }, };

            // Example: "https://southcentralus.api.cognitive.microsoft.com/customvision"
            var customVisionPredictionApi = RestService.For<ICustomVisionPredictionApi>("<YOUR-PREDICTION-API-BASE-HOST>");
            var result = await customVisionPredictionApi.PredictImageByUrlAsync(data);

            Console.WriteLine($"Project: {result.Project}, Id: {result.Id}, Created: {result.Created}, Iteration: {result.Iteration}");

            foreach (var prediction in result.Predictions)
            {
                Console.WriteLine($"Tag Id: {prediction.TagId}, Tag: {prediction.Tag}, Probability: {prediction.Probability}");
            }

            Console.ReadKey();
        }
    }
}
