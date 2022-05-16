using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    [Serializable]
    public class BlinkSkillLogic : SkillLogicBase
    {
        public int dis;

        protected override void Execute(RoleLogic roleLogic)
        {
            base.Execute(roleLogic);
            roleLogic.pos = roleLogic.pos + new Vector3(dis, 0, 0);
        }
    }
    
    [CreateAssetMenu(fileName = "AllLogicBlink", menuName = "CustomConfig/AllLogicBlink")]
    public class AllLogicBlink : ScriptableObject
    {
        public List<BlinkSkillLogic> lAllSkill = new List<BlinkSkillLogic>();
    }
}