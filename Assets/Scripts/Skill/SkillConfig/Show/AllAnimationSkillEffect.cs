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

        protected override void Execute(RoleView roleView)
        {
            base.Execute(roleView);
            GameUtils.ShowLog(string.Format("只见<color=red>{0}</color>用<color=red>{1}</color>摆出一副<color=red>{2}</color>", 
                roleView.GetLogic().Name, roleView.GetBodyDes(), aniName));
        }
    }
    [CreateAssetMenu(fileName = "AllAnimationSkillEffect", menuName = "CustomConfig/AllAnimationSkillEffect")]
    public class AllAnimationSkillEffect : ScriptableObject
    {
        public List<AnimationSkillEffect> lAllSkill = new List<AnimationSkillEffect>();
    }
}