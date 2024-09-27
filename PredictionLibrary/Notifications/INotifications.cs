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
}