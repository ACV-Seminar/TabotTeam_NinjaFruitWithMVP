using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP;
using UnityEngine.SceneManagement;

namespace MVP.View
{
    public sealed class MainMenuPresenter : IPresenter
    {
        public MainMenuPresenter()
        {
            
        }

        public void Init(IView view)
        {
            
        }

        public void Play()
        {
            SceneManager.LoadScene(Scene.GamePlayScene.ToString());
        }
    }
}