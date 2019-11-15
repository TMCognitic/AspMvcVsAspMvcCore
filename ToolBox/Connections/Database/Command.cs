using System;
using System.Collections.Generic;
using System.Text;

namespace ToolBox.Connections.Database
{
    public class Command
    {
        internal string Query { get; private set; }
        internal bool IsStoredProcedure { get; private set; }
        internal IDictionary<string, object> Parameters { get; private set; }

        public Command(string query, bool isStoredProcedure = false)
        {
            Parameters = new Dictionary<string, object>();
            Query = query;
            IsStoredProcedure = isStoredProcedure;
        }

        public void AddParameter(string parameterName, object value)
        {
            Parameters.Add(parameterName, (value is null) ? DBNull.Value : value);
        }
    }
}
