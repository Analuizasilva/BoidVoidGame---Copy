using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameModel
{
    [System.Serializable]
    public class Log
    {
        public DateTime Timestamp;
        public string Event;
    }

    [Serializable]
    public class LogViewModel
    {
        public Guid Id;
        public string Timestamp;
        public string Event;
        public Guid TurnId;


        public Log To()
        {
            var log = new Log();
            log.Event = Event;
            log.Timestamp = DateTime.Parse(Timestamp);
            return log;
        }

        public static LogViewModel From(Log log)
        {
            return new LogViewModel()
            {
                Timestamp = log.Timestamp.ToString(),
                Event = log.Event
            };
        }
    }
}
