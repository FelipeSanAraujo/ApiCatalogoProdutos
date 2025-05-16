
namespace APICatalogo.Logging
{
    public class CustomerLogger : ILogger
    {
        readonly string _loggerName;
        readonly CustomLoggerProviderConfig _config;

        public CustomerLogger(string loggerName, CustomLoggerProviderConfig config)
        {
            _loggerName = loggerName;
            _config = config;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel.Equals(_config.LogLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string mensagem = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

            EscreverTextoNoArquivo(mensagem);
        }

        private void EscreverTextoNoArquivo(string mensagem)
        {
            string path = @"C:\Logs\Logs.txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                try
                {
                    writer.WriteLine(mensagem);
                    writer.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
