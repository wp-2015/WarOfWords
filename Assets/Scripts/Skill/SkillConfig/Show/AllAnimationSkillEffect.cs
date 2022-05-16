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
            GameUtils.ShowLog(string.Format("切换了一个动作{0}", aniName));
        }

        public override SkillEffectBase Copy()
        {
            AnimationSkillEffect res = new AnimationSkillEffect();
            FillNewInstance(res);
            res.aniName = this.aniName;
            return res;
        }
    }
    [CreateAssetMenu(fileName = "AllAnimationSkillEffect", menuName = "CustomConfig/AllAnimationSkillEffect")]
    public class AllAnimationSkillEffect : ScriptableObject
    {
        public List<AnimationSkillEffect> lAllSkill = new List<AnimationSkillEffect>();
    }
}