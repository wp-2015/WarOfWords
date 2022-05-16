using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public enum SkillDamageShape
    {
        //Rect,
        Circle,
        //Sector,//扇形
    }
    [Serializable]
    public class DamageSkillLogic : SkillLogicBase
    {
        public SkillDamageShape shape;
        public float fValue1;
        public float fValue2;

        protected override void Execute(RoleLogic roleLogic)
        {
            base.Execute(roleLogic);
            GameUtils.ShowLog(string.Format("开始检测周围{0}米圆内的人，然后造成伤害", fValue1));
        }
    }
    
    [CreateAssetMenu(fileName = "AllLogicDamage", menuName = "CustomConfig/AllLogicDamage")]
    public class AllLogicDamage : ScriptableObject
    {
        public List<DamageSkillLogic> lAllSkill = new List<DamageSkillLogic>();
    }
}