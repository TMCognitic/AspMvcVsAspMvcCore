using System;
using System.Collections.Generic;
using System.Data;

namespace ToolBox.Connections.Database
{
    public interface IConnection
    {
        int ExecuteNonQuery(Command command);
        IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataRecord, TResult> selector);
        dynamic ExecuteScalar(Command command);
    }
}