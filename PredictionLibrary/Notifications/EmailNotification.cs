using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictionLibrary.Notifications
{
    public class EmailNotification : INotifications
	{
		public void Send(string message)
		{
			Console.WriteLine($"Email sent: {message}");
		}
	}
}