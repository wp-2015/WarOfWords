namespace WP
{
    public class AnimationSkillEffect : SkillEffectBase
    {
        public string szName;
        public override void Play()
        {
            GameUtils.ShowLog(string.Format("技能播放了一个动作：{0}", szName));
        }
    }
}