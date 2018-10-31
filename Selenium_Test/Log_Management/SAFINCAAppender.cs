using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.ObjectRenderer;
using log4net.Appender;
using log4net.Core;
using log4net.Util;
using log4net.Filter;
using log4net.Repository;
using log4net.Config;
using log4net;

namespace SAFINCA.LogMgn
{
    class SAFINCAAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            Level logLevel = Level.Error;
            switch (loggingEvent.Level.Name)
            {
                case "DEBUG":
                    logLevel = Level.Debug;
                    break;
                case "WARN":
                case "INFO":
                    logLevel = Level.Info;
                    break;
                case "ERROR":
                    logLevel = Level.Error;
                    break;
                case "FATAL":
                    logLevel = Level.Critical;
                    break;
            }
           //LogService.Log(LogNameEnum.Exception, LogCategoryEnum.BusinessLogic, logLevel, RenderLoggingEvent(loggingEvent));
            string logEv=RenderLoggingEvent(loggingEvent);
            System.Console.Write(logEv.Substring(logEv.IndexOf(":") + 2));
        }
    }
   
}
