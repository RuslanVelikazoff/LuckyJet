using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        MainMenuScene,
        PinkSunset,
        UnknownPlanet,
        ColdValley,
        LoadingScene
    }

    private static Scene targetScene;

    public static void Load(Scene targetScene)
    {
        Loader.targetScene = targetScene;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }

    public static Scene CurrentScene()
    {
        return Loader.targetScene;
    }
}
