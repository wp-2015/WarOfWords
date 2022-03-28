namespace WP
{
    public class AudioPlaySkillEffect : SkillEffectBase
    {
        public string szName;
        public override void Play()
        {
            GameUtils.ShowLog(string.Format("技能播放了一个音效：{0}", szName));
        }
    }
}