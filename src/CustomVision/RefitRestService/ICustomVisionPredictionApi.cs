using CustomVision.RefitRestService;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomVision.RefitRestService
{
    public interface ICustomVisionPredictionApi
    {
        // Example: [Post("/v1.0/Prediction/ff76e214-c6ab-4eb2-bb2c-d34c3ca65bcc/url")]
        [Post("<YOUR-PREDICTION-API-RESOURCE-ENDPOINT>")]

        // Example: [Headers("Prediction-Key: a63298872abc4e7deabcd78beec819a2", "Content-Type: application/json; charset=UTF-8")]
        [Headers("Prediction-Key: <YOUR-PREDICTION-KEY>", "Content-Type: application/json; charset=UTF-8")]

        Task<PredictionResponse> PredictImageByUrlAsync([Body(BodySerializationMethod.Json)] Dictionary<string, object> content);
    }
}
