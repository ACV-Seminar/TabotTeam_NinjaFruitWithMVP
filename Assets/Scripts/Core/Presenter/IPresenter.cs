using MVP.Model;
using System;
using System.Collections.Generic;

namespace MVP
{
    public interface IPresenter
    {
        void Init(IView view);
    }
}
