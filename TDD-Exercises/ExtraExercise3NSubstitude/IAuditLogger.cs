using System.Collections.Generic;

namespace ExtraExercise3NSubstitute
{
    public interface IAuditLogger
    {
        void AddMessage(string message);
        List<string> GetLog();
    }
}