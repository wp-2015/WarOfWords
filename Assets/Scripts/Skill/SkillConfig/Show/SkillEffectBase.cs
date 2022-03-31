using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public enum SkillEffectType
    {
        None,
        AudioPlay,
        Animation,
        Effect,
    }
    //SkillEffectBase   AudioSkillEffect    AnimationSkillEffect    EffectSkillEffect
    
    [Serializable]
    public class SkillEffectBase : SkillStepCellBase
    {
        public SkillEffectType type;
        public int id;
    }
    
    [Serializable]
    public class AudioSkillEffect : SkillEffectBase
    {
        public string audioName;
    }
    [CreateAssetMenu(fileName = "AllAudioSkillEffect", menuName = "CustomConfig/AllAudioSkillEffect")]
    public class AllAudioSkillEffect : ScriptableObject
    {
        public List<AudioSkillEffect> lAllSkill = new List<AudioSkillEffect>();
    }

    [Serializable]
    public class AnimationSkillEffect : SkillEffectBase
    {
        public string aniName;
    }
    [CreateAssetMenu(fileName = "AllAnimationSkillEffect", menuName = "CustomConfig/AllAnimationSkillEffect")]
    public class AllAnimationSkillEffect : ScriptableObject
    {
        public List<AnimationSkillEffect> lAllSkill = new List<AnimationSkillEffect>();
    }

    [Serializable]
    public class EffectSkillEffect : SkillEffectBase
    {
        public string prefabPath;
        public bool bIsWorld;//是否是在世界放置，还是在身上放置
    }
    
    [CreateAssetMenu(fileName = "AllEffectSkillEffect", menuName = "CustomConfig/AllEffectSkillEffect")]
    public class AllEffectSkillEffect : ScriptableObject
    {
        public List<EffectSkillEffect> lAllSkill = new List<EffectSkillEffect>();
    }
}