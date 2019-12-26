using Get.the.solution.Image.Manipulation.ServiceBase;
using System;
using System.Collections.Generic;

namespace ResizeImage.Service
{
    public class LoggerService : LoggerBaseService
    {
        public override void LogEvent(string eventName)
        {
            Console.WriteLine(eventName);
        }

        public override void LogEvent(string eventName, IDictionary<string, string> data)
        {
            Console.WriteLine(eventName);
        }
    }
}
