using UnityEngine;

public static class SystemManager
{
    public static GameSettings settings;
    public static Camera mainCam;
    public static Font DEFAULT_FONT;

    [RuntimeInitializeOnLoadMethod]
    static void StartApplication()
    {
        DEFAULT_FONT = Resources.GetBuiltinResource<Font>("Arial.ttf");

        settings = new GameSettings();
    }
}