# Azure Cognitive Services Samples

A simple .NET Core 2.0 (c# v7.1) code sample to invoke Azure's Custom Vision Service Prediction API using [Refit](https://github.com/paulcbetts/refit)

## Getting started
* Visual Studio 2017 (v15.3.3), .NET Core 2.0 installed
* Head to the [Custom Vision Service quickstarts](https://docs.microsoft.com/en-us/azure/cognitive-services/custom-vision-service/getting-started-build-a-classifier) and follow the basic steps to build a classifier that you'd like.
* Get your Prediction API Host and Key in https://customvision.ai > Performance > Prediction URL
* In the repo source, replace YOUR-PREDICTION-API-BASE-HOST in [Program.cs](https://github.com/CarlosSardo/CognitiveServicesSamples/blob/master/src/CustomVision/Program.cs) with the Base API Host
```csharp
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
```

* And replace YOUR-PREDICTION-API-RESOURCE-ENDPOINT and YOUR-PREDICTION-KEY in [ICustomVisionPredictionApi.cs](https://github.com/CarlosSardo/CognitiveServicesSamples/blob/master/src/CustomVision/RefitRestService/ICustomVisionPredictionApi.cs)

```csharp
    public interface ICustomVisionPredictionApi
    {
        // Example: [Post("/v1.0/Prediction/ff76e214-c6ab-4eb2-bb2c-d34c3ca65bcc/url")]
        [Post("<YOUR-PREDICTION-API-RESOURCE-ENDPOINT>")]

        // Example: [Headers("Prediction-Key: a63298872abc4e7deabcd78beec819a2", "Content-Type: application/json; charset=UTF-8")]
        [Headers("Prediction-Key: <YOUR-PREDICTION-KEY>", "Content-Type: application/json; charset=UTF-8")]

        Task<PredictionResponse> PredictImageByUrlAsync([Body(BodySerializationMethod.Json)] Dictionary<string, object> content);
    }
```

* Go to the command line, to the directory where you cloned the repo:
```csharp
> dotnet restore
> dotnet build src/CognitiveServicesSamples.sln
> dotnet run --project src/CustomVision/CustomVision.csproj https://website-example.com/images/image.jpg
```
* And enjoy the console output (should be something like this):
```cli
Project: ed6edb1d-335b-486c-9404-64e5e0fdf319, Id: cbf78812-cbdc-48e4-bbf2-49e5b6a835fe, Created: 4-9-2017 14:28:32, Iteration: b82b484d-d62d-4932-b10a-f2e12966ad74
Tag Id: 2da388ba-1f63-4e5f-9e23-c5ed9c05bdce, Tag: 1040, Probability: 0,9996263
Tag Id: 3634a6bc-58b3-4be1-83b9-9de1654f4841, Tag: 1099, Probability: 2,27343E-14
```



