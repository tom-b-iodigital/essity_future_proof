using Essity.FutureProof.Domain.Enums;

namespace Essity.FutureProof.Domain.Interfaces
{
    public interface IEssityLog
    {
        void Error<T>(string message, Exception exception, string debugInfo = "");

        void Info<T>(string message);

        void Log<T>(string message, Exception exception, LogLevel level = LogLevel.Error, string debugInfo = "");
    }
}
