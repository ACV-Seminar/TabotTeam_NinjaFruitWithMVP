using System;

namespace MVP
{
    public interface IScene
    {
        string ServerScene { get; }
        string SceneName { get; }
        Scene SceneType { get; }
        void BeginScene();
        void EndScene();
    }
}