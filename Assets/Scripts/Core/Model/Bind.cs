using System;

namespace MVP.Model
{
    public class Bind<T>
    {
        public Action<T> onChange;

        private T _data;

        public T Value
        {
            get;
            set;
        }
    }
}