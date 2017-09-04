using System;
using System.Collections.Generic;
using System.Text;

namespace CustomVision.RefitRestService
{
    public class PredictionResponse
    {
        public string Id { get; set; }
        public string Project { get; set; }
        public string Iteration { get; set; }
        public DateTime Created { get; set; }
        public Prediction[] Predictions { get; set; }
    }
}
