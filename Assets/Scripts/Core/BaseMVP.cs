using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVP.Model;

namespace MVP.View
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

        public abstract void BindModel(IDataModel data);
    }
}