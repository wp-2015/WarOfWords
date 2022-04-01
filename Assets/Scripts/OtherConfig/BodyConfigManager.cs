namespace WP
{
    public class BodyConfigManager: Singleton_CSharp<BodyConfigManager>
    {
        public BodyConfig bodyConfig;
        public BodyConfig faceConfig;
        public BodyConfig voiceConfig;
        public BodyConfig handConfig;
        public BodyConfig footConfig;
        public void Init()
        {
            bodyConfig = GameUtils.LoadAsset<BodyConfig>(GameConst.BodyConfigPath);
            faceConfig = GameUtils.LoadAsset<BodyConfig>(GameConst.FaceConfigPath);
            voiceConfig = GameUtils.LoadAsset<BodyConfig>(GameConst.VoiceConfigPath);
            handConfig = GameUtils.LoadAsset<BodyConfig>(GameConst.HandConfigPath);
            footConfig = GameUtils.LoadAsset<BodyConfig>(GameConst.FootConfigPath);
        }
    }
}