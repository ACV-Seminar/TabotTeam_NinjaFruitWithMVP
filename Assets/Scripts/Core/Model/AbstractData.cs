using System;
using System.Collections.Generic;
using System.Reflection;

namespace MVP.Model
{
    public class AbstractData : IDataModel
    {
        Action<IDataModel> _onDataChanged;
        public event Action<IDataModel> onDataChanged
        {
            add { _onDataChanged += value; }
            remove { _onDataChanged -= value; }
        }

        Action<IDataModel, string> _onAttributeChange;
        public event Action<IDataModel, string> onAttributeChange
        {
            add { _onAttributeChange += value; }
            remove { _onAttributeChange -= value; }
        }

        public Dictionary<string, object> ToDictionary()
        {
            var result = new Dictionary<string, object>();
            System.Type T = GetType();
            FieldInfo[] fields = T.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            foreach (FieldInfo f in fields)
                result.Add(f.Name, f.GetValue(this));

            return result;
        }
    }
}
