using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    //技能配置
    //一个技能有很多阶段
    //一个阶段有很多表现来组合

    [CreateAssetMenu(fileName = "CustomScriptableObject", menuName = "CustomConfig/SkillShowConfig")]
    public class SkillShowConfig : ScriptableObject
    {
        public string name;
        public int id;//技能ID
        public List<SkillShowStep> lAllSkillShowStep = new List<SkillShowStep>();
    }

    public class SkillShowStep
    {
        public List<SkillEffectBase> lAllSkillEffect = new List<SkillEffectBase>();
    }
}
