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

        protected override void Execute(RoleView roleView)
        {
            base.Execute(roleView);
            GameUtils.ShowLog(string.Format("播放了一个音效:{0}", audioName));
        }

        public override SkillEffectBase Copy()
        {
            AudioSkillEffect res = new AudioSkillEffect();
            FillNewInstance(res);
            res.audioName = this.audioName;
            return res;
        }
    }
    [CreateAssetMenu(fileName = "AllAudioSkillEffect", menuName = "CustomConfig/AllAudioSkillEffect")]
    public class AllAudioSkillEffect : ScriptableObject
    {
        public List<AudioSkillEffect> lAllSkill = new List<AudioSkillEffect>();
    }
}