using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PredictionLibrary.Predictions;

namespace PredictionLibrary.Repository
{
    public class PredictionRepository
    {
        private List<Prediction> _predictions = new List<Prediction>();

		public void SavePrediction(Prediction prediction)
		{
			_predictions.Add(prediction);
			Console.WriteLine($"Prediction saved: {prediction.Text}");
		}

		public void DisplayAllPredictions()
		{
			foreach (var prediction in _predictions)
			{
				prediction.DisplayPrediction();
			}
		}
    }
}