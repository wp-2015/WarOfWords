using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    //技能配置
    //一个技能有很多阶段
    //一个阶段有很多表现来组合
    //SkillShowConfig   SkillInfo   SkillShowStep

    [CreateAssetMenu(fileName = "CustomScriptableObject", menuName = "CustomConfig/SkillShowConfig")]
    public class SkillShowConfig : ScriptableObject
    {
        public List<SkillInfo> lAllSkill = new List<SkillInfo>();
    }

    [Serializable]
    public class SkillInfo
    {
        public string name;
        public int id;//技能ID
        public List<SkillShowStep> lAllSkillShowStep = new List<SkillShowStep>();
    }
    
    [Serializable]
    public class SkillEffectItem
    {
        public SkillEffectType type;
        public int id;
    }

    [Serializable]
    public class SkillShowStep
    {
        public float time;//持续时间
        public List<SkillEffectItem> lEffectsInSaving = new List<SkillEffectItem>();
        [HideInInspector]
        public List<SkillEffectBase> lAllSkillEffectInPlaying = new List<SkillEffectBase>();
    }
}