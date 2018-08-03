using System;
using System.Collections.Generic;

namespace MVP
{
    public interface IView
    {
        void BindData();
        void BindModel<T>(T data);
    }
}