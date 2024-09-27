using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictionLibrary.Notifications
{
    public interface INotifications
    {
        void Send(string message);
	}

	public class EmailNotification : INotifications
	{
		public void Send(string message)
		{
			Console.WriteLine($"Email sent: {message}");
		}
	}

	public class SmsNotification : INotifications
	{
		public void Send(string message)
		{
			Console.WriteLine($"SMS sent: {message}");
		}
	}
}