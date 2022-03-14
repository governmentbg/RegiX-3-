using TechnoLogica.RegiX.RecordLog;

namespace TechnoLogica.RegiX.Core.Data.Interfaces
{
    public interface ILogRecord
    {
        void LogRecord(string operationFullName, RegiXLogRecordType logRecord, string error);
    }
}