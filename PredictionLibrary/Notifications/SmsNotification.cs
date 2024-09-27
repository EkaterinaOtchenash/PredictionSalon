using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictionLibrary.Notifications
{
    public class SmsNotification : INotifications
	{
		public void Send(string message)
		{
			Console.WriteLine($"SMS sent: {message}");
		}
	}
}