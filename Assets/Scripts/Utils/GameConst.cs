using UnityEngine;

public static class GameConst
{
    public const string GameLogicRoot = "GameLogicRoot";

    private static GameObject gameLogicRoot;
    public static GameObject GameLogicRootGameObject
    {
        get
        {
            if (null == gameLogicRoot)
            {
                gameLogicRoot = new GameObject();
                UnityEngine.Object.DontDestroyOnLoad(gameLogicRoot);
            }
            return gameLogicRoot;
        }
    }

    public const int MaxStrength = 99;

    public static string BodyConfigPath = "Config/BodyConfig";
    public static string FaceConfigPath = "Config/FaceConfig";
    public static string VoiceConfigPath = "Config/VoiceConfig";
    public static string HandConfigPath = "Config/HandConfig";
    public static string FootConfigPath = "Config/FootConfig";

    public static string SkillShowConfig = "SkillConfig/SkillShow/SkillShowConfig";
    public static string AllAudioSkillEffect = "SkillConfig/SkillShow/AllAudioSkillEffect";
    public static string AllAnimationSkillEffect = "SkillConfig/AllSkillShow/AnimationSkillEffect";
    public static string AllEffectSkillEffect = "SkillConfig/SkillShow/AllEffectSkillEffect";

}