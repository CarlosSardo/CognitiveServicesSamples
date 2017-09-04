using System;
using System.Collections.Generic;
using System.Text;

namespace CustomVision.RefitRestService
{
    public class Prediction
    {
        public string TagId { get; set; }
        public string Tag { get; set; }
        public float Probability { get; set; }
    }
}
