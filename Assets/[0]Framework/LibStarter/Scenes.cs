﻿namespace Homebrew
{
    [System.Flags]
    public enum Scenes
    {
        sceneLevel1 = 0,
        sceneLv1Room6 = 1,
        sceneKernel = 2,
        sceneCamera = 3,
        sceneLv1Room5 = 4,
        sceneLoader = 5
    }

    public static partial class Game
    {
        public static void To(Scenes scene)
        {
            ProcessingSceneLoad.To((int) scene);
        }

        public static void Add(Scenes scene)
        {
            ProcessingSceneLoad.Add((int) scene);
        }

        public static void Remove(Scenes scene)
        {
            ProcessingSceneLoad.Remove((int) scene);
        }
    }
}