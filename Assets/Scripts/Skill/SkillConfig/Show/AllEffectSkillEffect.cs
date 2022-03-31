using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WP
{
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