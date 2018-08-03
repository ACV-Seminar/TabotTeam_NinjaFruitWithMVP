using System;
using System.Collections.Generic;

namespace MVP.Model
{
    public interface IDataModel
    {
        Dictionary<string, object> ToDictionary();
        string ToString();
    }
}