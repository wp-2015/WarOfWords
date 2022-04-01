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

        public override void Enter()
        {
            base.Enter();
            GameUtils.ShowLog(string.Format("播放了一个音效:{0}", audioName));
        }
    }
    [CreateAssetMenu(fileName = "AllAudioSkillEffect", menuName = "CustomConfig/AllAudioSkillEffect")]
    public class AllAudioSkillEffect : ScriptableObject
    {
        public List<AudioSkillEffect> lAllSkill = new List<AudioSkillEffect>();
    }
}