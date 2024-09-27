using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PredictionLibrary.Notifications;
using PredictionLibrary.Repository;

namespace PredictionLibrary.Predictions
{
    public class PredictionProcessor
    {
        private readonly Prediction _prediction;
    private readonly INotifications _notification;
    private readonly PredictionRepository _repository;

    public PredictionProcessor(Prediction prediction, INotifications notification, PredictionRepository repository)
    {
        _prediction = prediction;
        _notification = notification;
        _repository = repository;
    }

    public void ProcessPrediction()
    {
        // Обрабатываем предсказание
        Console.WriteLine("Processing prediction: " + _prediction.Text);

        // Добавляем предсказание в репозиторий
        _repository.SavePrediction(_prediction);

        // Отправляем уведомление
        _notification.Send(_prediction.Text);
    }
    }
}