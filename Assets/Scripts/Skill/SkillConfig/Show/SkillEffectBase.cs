namespace WP
{
    public enum SkillEffectType
    {
        None,
        AudioPlay,
        Animation,
        Effect,
    }
    public class SkillEffectBase
    {
        
    }

    public class AudioSkillEffect : SkillEffectBase
    {
        public string name;
    }

    public class AnimationSkillEffect : SkillEffectBase
    {
        public string name;
    }

    public class EffectSkillEffect : SkillEffectBase
    {
        public string prefabPath;
        public bool bIsWorld;//是否是在世界放置，还是在身上放置
    }
}