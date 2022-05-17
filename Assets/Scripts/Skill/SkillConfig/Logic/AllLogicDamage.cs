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
            
            GameUtils.ShowLog(String.Format("{0}:报告,我将对{1}单位范围内的人造成伤害", 
                roleLogic.Name, fValue1));
            Buff(roleLogic, fValue1);
        }

        private void Buff(RoleLogic roleLogic, float dis)
        {
            var pos = roleLogic.pos;
            var roleLogics = EntityManager.Instance.GetTypeEntity("RoleLogic");
            foreach (var target in roleLogics)
            {
                var targetLogic = target as RoleLogic;
                if (targetLogic != null && roleLogic != targetLogic && Vector3.Distance(target.pos, roleLogic.pos) < dis)
                {
                    foreach (var buffID in lBuffIDs)
                    {
                        var buffInfo = SkillManager.Instance.GetBuffInfo(buffID);
                        GameUtils.ShowLog(String.Format("{0}:报告,我的攻击将对{1}产生{2}效果", 
                            roleLogic.Name, targetLogic.Name, buffInfo.name));
                        targetLogic.AddBuff(buffID);
                    }
                }
            }
        }
    }
    
    [CreateAssetMenu(fileName = "AllLogicDamage", menuName = "CustomConfig/AllLogicDamage")]
    public class AllLogicDamage : ScriptableObject
    {
        public List<DamageSkillLogic> lAllSkill = new List<DamageSkillLogic>();
    }
}