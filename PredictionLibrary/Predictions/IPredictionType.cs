using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictionLibrary.Predictions
{
    public interface IPredictionType
    {
        Prediction GetPrediction();
    }

    public class PositivePrediction : IPredictionType
    {
        private static readonly List<string> Predictions = new List<string>
        {
            "Сегодня вас ждет удача!",
            "Ваши мечты сбудутся.",
            "Сегодня идеальный день для новых начинаний."
        };

        public Prediction GetPrediction()
        {
            Random random = new Random();
            string predictionText = Predictions[random.Next(Predictions.Count)];
            return new Prediction(predictionText, "Positive");
        }
    }
}