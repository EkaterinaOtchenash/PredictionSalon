using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictionLibrary.Predictions
{
        public class NeutralPrediction : IPredictionType
    {
        private static readonly List<string> Predictions = new List<string>
        {
            "Сегодня все пойдет как обычно.",
            "Ничего особенного не случится.",
            "Это будет обычный день."
        };

        public Prediction GetPrediction()
        {
            Random random = new Random();
            string predictionText = Predictions[random.Next(Predictions.Count)];
            return new Prediction(predictionText, "Neutral");
        }
    }
}