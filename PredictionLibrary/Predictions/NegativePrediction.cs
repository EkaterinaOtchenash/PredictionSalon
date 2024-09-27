using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictionLibrary.Predictions
{
    public class NegativePrediction : IPredictionType
    {
        private static readonly List<string> Predictions = new List<string>
        {
            "Сегодня может случиться что-то неприятное.",
            "Берегитесь трудностей.",
            "Будьте осторожны, удача не на вашей стороне."
        };

        public Prediction GetPrediction()
        {
            Random random = new Random();
            string predictionText = Predictions[random.Next(Predictions.Count)];
            return new Prediction(predictionText, "Negative");
        }
    }
}