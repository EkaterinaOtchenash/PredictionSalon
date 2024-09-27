using System;
using System.Collections.Generic;

namespace PredictionLibrary.Predictions
{
    public class Prediction
    {
        public string Text { get; }
        public string Type { get; }

        public Prediction(string text, string type)
        {
            Text = text;
            Type = type;
        }

		public void DisplayPrediction()
    {
        Console.WriteLine($"Prediction: {Text} (Category: {Type})");
    }
    }
}
