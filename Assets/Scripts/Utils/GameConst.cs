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

    public const string BodyConfigPath = "Config/BodyConfig";
    public const string FaceConfigPath = "Config/FaceConfig";
    public const string VoiceConfigPath = "Config/VoiceConfig";
    public const string HandConfigPath = "Config/HandConfig";
    public const string FootConfigPath = "Config/FootConfig";

    public const string SkillConfig = "SkillConfig/SkillConfig";
    public const string BuffConfig = "SkillConfig/BuffConfig";
    
    public const string AllAudioSkillEffect = "SkillConfig/SkillShow/AllAudioSkillEffect";
    public const string AllAnimationSkillEffect = "SkillConfig/SkillShow/AllAnimationSkillEffect";
    public const string AllEffectSkillEffect = "SkillConfig/SkillShow/AllEffectSkillEffect";

    public const string AllLogicBlink = "SkillConfig/SkillLogic/AllLogicBlink";
    public const string AllLogicDamage = "SkillConfig/SkillLogic/AllLogicDamage";
}