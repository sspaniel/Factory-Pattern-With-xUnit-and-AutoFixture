using System;

namespace xUnitAutoFixture.Models
{
    public class Log
    {
        public Log(string message)
        {
            DateTimeUtc = DateTime.UtcNow;
            Message = message;
        }

        public readonly DateTime DateTimeUtc;
        public readonly string Message;
    }
}
