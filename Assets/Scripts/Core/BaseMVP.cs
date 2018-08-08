using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVP
{
    public abstract class BaseMVP<P> : UnityEngine.MonoBehaviour, IView where P : IPresenter, new()
    {
        protected P presenter;

        void Awake()
        {
            presenter = new P();
            Init();
        }

        protected abstract void Init();

        public abstract void BindData();

        public abstract void BindModel<T>(T data);
    }
}