using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictionLibrary.Predictions
{
    public class RandomPredictionGenerator
    {
        private static readonly List<IPredictionType> PredictionTypes = new List<IPredictionType>
        {
            new PositivePrediction(),
            new NeutralPrediction(),
            new NegativePrediction()
        };

        public Prediction GetRandomPrediction()
        {
            Random random = new Random();
            IPredictionType randomPredictionType = PredictionTypes[random.Next(PredictionTypes.Count)];
            return randomPredictionType.GetPrediction();
        }
    }
}