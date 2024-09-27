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