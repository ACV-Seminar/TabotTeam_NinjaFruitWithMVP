using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP;

namespace MVP.View
{
    public sealed class GamePlayPresenter : IPresenter
    {
        private bool dragging = false;
        private Vector2 swipeStart;

        public bool Dragging
        {
            get
            {
                return dragging;

            }
            set
            {
                dragging = value;
            }
        }
        public Vector2 SwipeStart
        {
            get
            {
                return swipeStart;
            }
            set
            {
                swipeStart = value;
            }
        }

        public void Init(IView view)
        {
        }

        public GamePlayPresenter()
        {
        }
    }

}