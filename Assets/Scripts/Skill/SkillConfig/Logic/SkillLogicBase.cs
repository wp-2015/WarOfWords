using System;
using UnityEngine;

namespace WP
{
    [Serializable]
    public class SkillLogicBase
    {
        public RoleLogic roleLogic;
        public int id;
        public int delayTimeMillisecond;

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