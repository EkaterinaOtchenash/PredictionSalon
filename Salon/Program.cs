using System;
using System.Collections.Generic;
using PredictionLibrary;
using PredictionLibrary.Notifications;
using PredictionLibrary.Predictions;
using PredictionLibrary.Repository;

namespace Salon
{
	public class Program
	{
		public static void Main(string[] args)
        {
            PredictionRepository repository = new PredictionRepository();
            RandomPredictionGenerator randomPredictionGenerator = new RandomPredictionGenerator();

            Console.WriteLine("Welcome to the Prediction Salon!");

            // Вместо выбора пользователем, теперь тип предсказания выбирается случайно.
            Prediction randomPrediction = randomPredictionGenerator.GetRandomPrediction();

            Console.WriteLine("Randomly selected prediction type: " + randomPrediction.Type);
            Console.WriteLine("Prediction: " + randomPrediction.Text);

            Console.WriteLine("Choose the type of notification: 1 - Email, 2 - SMS");
            int notificationChoice = int.Parse(Console.ReadLine());

            INotifications notification = notificationChoice switch
            {
                1 => new EmailNotification(),
                2 => new SmsNotification(),
                _ => new EmailNotification() // Default to Email if input is invalid
            };

            // Теперь PredictionProcessor получает рандомное предсказание
            PredictionProcessor processor = new PredictionProcessor(randomPrediction, notification, repository);

            processor.ProcessPrediction();

            Console.WriteLine("\nAll predictions so far:");
            repository.DisplayAllPredictions();
        }
	}
}