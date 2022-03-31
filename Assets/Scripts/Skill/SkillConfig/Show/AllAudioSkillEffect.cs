using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WP
{
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
}