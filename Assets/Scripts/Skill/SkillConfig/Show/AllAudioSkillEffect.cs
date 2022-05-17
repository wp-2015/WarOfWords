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
            GameUtils.ShowLog(string.Format("<color=red>{0}</color>用<color=red>{1}</color>说了一声:<color=red>{2}</color>", 
                roleView.GetLogic().Name, roleView.GetVoiceDes(), audioName));
        }
    }
    
    [CreateAssetMenu(fileName = "AllAudioSkillEffect", menuName = "CustomConfig/AllAudioSkillEffect")]
    public class AllAudioSkillEffect : ScriptableObject
    {
        public List<AudioSkillEffect> lAllSkill = new List<AudioSkillEffect>();
    }
}