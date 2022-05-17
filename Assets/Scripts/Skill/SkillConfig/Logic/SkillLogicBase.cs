using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    [Serializable]
    public class SkillLogicBase
    {
        public RoleLogic roleLogic;
        public string name;
        public int id;
        public int delayTimeMillisecond;
        public List<int> lBuffIDs = new List<int>();

        public virtual void Play(RoleLogic roleLogic)
        {
            roleLogic.AddTimeEventToDo(
                TimeHandleManager.Instance.AddHandleMillisecond(delayTimeMillisecond, () =>
                {
                    Execute(roleLogic);
                })
            );
        }

        protected virtual void Execute(RoleLogic roleLogic)
        {
            
        }
    }

    
}