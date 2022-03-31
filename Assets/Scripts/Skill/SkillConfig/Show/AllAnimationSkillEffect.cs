using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WP
{
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
}