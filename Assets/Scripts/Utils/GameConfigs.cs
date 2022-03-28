using WP.OtherConfig;

namespace Utils
{
    public static class GameConfigs
    {
        public static BodyConfig bodyConfig;
        public static BodyConfig faceConfig;
        public static BodyConfig voiceConfig;
        public static BodyConfig handConfig;
        public static BodyConfig footConfig;
        public static void Init()
        {
            bodyConfig = GameUtils.LoadAsset<BodyConfig>(GameConst.BodyConfigPath);
            faceConfig = GameUtils.LoadAsset<BodyConfig>(GameConst.FaceConfigPath);
            voiceConfig = GameUtils.LoadAsset<BodyConfig>(GameConst.VoiceConfigPath);
            handConfig = GameUtils.LoadAsset<BodyConfig>(GameConst.HandConfigPath);
            footConfig = GameUtils.LoadAsset<BodyConfig>(GameConst.FootConfigPath);
        }
    }
}