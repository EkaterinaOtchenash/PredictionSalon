### Отчёт по проекту "Prediction Salon"

#### Введение
Данный проект реализует салон предсказаний, который генерирует предсказания трёх видов (позитивное, нейтральное, негативное) и отправляет их пользователю через выбранный способ уведомления (email или SMS). Для решения задачи применяются принципы объектно-ориентированного программирования (ООП), такие как инкапсуляция, полиморфизм, абстракция и разделение обязанностей.

---

### Принципы ООП, реализованные в проекте

#### 1. **Инкапсуляция**
**Описание:**
- Инкапсуляция — это механизм, позволяющий скрыть детали реализации от внешнего мира и предоставлять доступ только к определённым частям данных или функционала через публичные методы.
- Применяется, когда необходимо защитить данные объекта от некорректного доступа или изменений.

**Пример в проекте:**
- Классы [PositivePrediction](PredictionLibrary/Predictions/IPredictionType.cs), [NeutralPrediction](PredictionLibrary/Predictions/IPredictionType.cs), [NegativePrediction](PredictionLibrary/Predictions/IPredictionType.cs) скрывают внутренние списки предсказаний и предоставляют только один метод `GetPrediction()`, который возвращает случайное предсказание.
  
**Пример**
```csharp
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
```

**Проблемы, которые решает инкапсуляция:**
- Защита данных (списки предсказаний скрыты от внешнего мира).
- Сокрытие деталей реализации (пользователю не нужно знать, как именно предсказание выбирается).

**Вывод:**  
Инкапсуляция в данном проекте позволяет обеспечить корректное использование классов, минимизируя возможные ошибки при взаимодействии с ними.

---

#### 2. **Полиморфизм**
**Описание:**
- Полиморфизм позволяет использовать один и тот же интерфейс для работы с разными типами объектов.
- Применяется, когда нужно обеспечить единообразное поведение для разных реализаций одного интерфейса.

**Пример в проекте:**
- Интерфейс `IPredictionType` реализуется разными классами (`PositivePrediction`, `NeutralPrediction`, `NegativePrediction`), что позволяет использовать общий метод `GetPrediction()` для получения любого типа предсказания.

**Пример:**
```csharp
public interface IPredictionType
{
    Prediction GetPrediction();
}
```
```csharp
IPredictionType predictionType = predictionChoice switch
{
    1 => new PositivePrediction(),
    2 => new NeutralPrediction(),
    3 => new NegativePrediction(),
    _ => new NeutralPrediction()
};
```

**Проблемы, которые решает полиморфизм:**
- Упрощение кода: не нужно писать отдельную логику для каждого типа предсказания.
- Легкость расширения: добавление нового типа предсказания не требует изменения существующего кода.

**Вывод:**  
Полиморфизм упрощает управление предсказаниями, позволяя обрабатывать их через один интерфейс и легко добавлять новые виды предсказаний.

---

#### 3. **Абстракция**
**Описание:**
- Абстракция скрывает детали реализации и предоставляет только наиболее важные характеристики объекта.
- Применяется для уменьшения сложности системы, позволяя пользователям взаимодействовать только с ключевыми функциями объекта.

**Пример в проекте:**
- Абстрактный интерфейс `INotifications` позволяет скрыть реализацию конкретных способов уведомлений (email и SMS) и работать с ними через единый метод `Send()`.

**Пример**
```csharp
public interface INotifications
{
    void Send(string message);
}
```
```csharp
INotifications notification = notificationChoice switch
{
    1 => new EmailNotification(),
    2 => new SmsNotification(),
    _ => new EmailNotification()
};
```

**Проблемы, которые решает абстракция:**
- Сокращает сложность системы, скрывая от пользователя детали реализации различных типов уведомлений.
- Позволяет легко добавлять новые способы уведомления без изменения основной логики программы.

**Вывод:**  
Абстракция в проекте позволяет скрыть детали отправки уведомлений и сосредоточиться на ключевых задачах — генерации и отправке предсказаний.

---

#### 4. **Разделение обязанностей (Single Responsibility Principle)**
**Описание:**
- Принцип разделения обязанностей гласит, что каждый класс должен иметь одну единственную обязанность.
- Применяется для улучшения поддержки и расширяемости кода.

**Пример в проекте:**
- Класс `PredictionRepository` отвечает только за хранение и отображение предсказаний, класс `PredictionProcessor` — за обработку предсказаний, а классы уведомлений `EmailNotification` и `SmsNotification` — за отправку сообщений.

**Пример**
```csharp
public class PredictionRepository
{
    private readonly List<Prediction> _predictions = new List<Prediction>();

    public void AddPrediction(Prediction prediction)
    {
        _predictions.Add(prediction);
    }

    public void DisplayAllPredictions()
    {
        foreach (var prediction in _predictions)
        {
            Console.WriteLine($"Prediction: {prediction.Text} - Type: {prediction.Type}");
        }
    }
}
```

**Проблемы, которые решает разделение обязанностей:**
- Чёткое распределение задач между классами упрощает их поддержку и расширение.
- Лёгкость в тестировании: каждый класс можно тестировать изолированно.

**Вывод:**  
Принцип разделения обязанностей позволяет поддерживать проект в чистоте, делая код более понятным и легко поддерживаемым.

---

### Заключение
В данном проекте успешно применены ключевые принципы ООП. Эти принципы позволяют улучшить архитектуру программы, сделав её расширяемой, поддерживаемой и устойчивой к ошибкам. Каждый принцип решает конкретные проблемы, связанные с сложностью, поддерживаемостью и безопасностью кода.

---
