using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace WP
{
    [CreateAssetMenu(fileName = "CustomScriptableObject", menuName = "CustomConfig/SkillShowConfig")]
    public class SkillConfig : ScriptableObject
    {
        public List<SkillInfo> lAllSkill = new List<SkillInfo>();
    }

    [Serializable]
    public class SkillInfo
    {
        public string name;
        public int id;//技能ID
        public List<SkillStep> lAllSkillStep = new List<SkillStep>();
    }
    
    [Serializable]
    public class SkillEffectItem
    {
        public SkillEffectType type;
        public int id;
    }

    [Serializable]
    public class SkillLogicItem
    {
        public SkillLogicType type;
        public int id;
    }

    [Serializable]
    public class SkillStep
    {
        public float time;//持续时间
        
        //view
        public List<SkillEffectItem> lEffectsInSaving = new List<SkillEffectItem>();
        [HideInInspector]
        public List<SkillEffectBase> lAllSkillEffectInPlaying = new List<SkillEffectBase>();
        
        //logic
        public List<SkillLogicItem> lLogicsInSaving = new List<SkillLogicItem>();
        [HideInInspector]
        public List<SkillLogicBase> lAllSkillLogicInPlaying = new List<SkillLogicBase>();
    }
}