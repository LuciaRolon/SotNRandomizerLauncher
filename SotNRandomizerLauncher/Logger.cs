using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotNRandomizerLauncher
{
    internal class Logger
    {
        private readonly TraceSource _traceSource;

        public Logger()
        {
            // Initialize TraceSource and configure the listener
            _traceSource = new TraceSource("LogTraceSource", SourceLevels.All);

            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "errorlogs.txt");

            // Ensure the logs directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

            var textListener = new TextWriterTraceListener(logFilePath)
            {
                TraceOutputOptions = TraceOptions.DateTime | TraceOptions.Callstack
            };

            // Clear default listeners and add the new one
            _traceSource.Listeners.Clear();
            _traceSource.Listeners.Add(textListener);
        }

        public void LogError(string context, string message, string[] arguments)
        {
            _traceSource.TraceEvent(TraceEventType.Error, 0, $"[ERROR] (Context: {context} - Message: {message} - Variables: {arguments}");
            _traceSource.Flush();
        }

        public void LogError(string context, string message, string arguments)
        {
            _traceSource.TraceEvent(TraceEventType.Error, 0, $"[ERROR] (Context: {context} - Message: {message} - Variables: {arguments}");
            _traceSource.Flush();
        }
    }
}
