using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    [Serializable]
    public class SkillEffectBase
    {
        public RoleView roleView;
        public string name;
        public int id;
        public int delayTimeMillisecond;

        public void Play(RoleView roleView)
        {
            roleView.AddTimeEventToDo(
                TimeHandleManager.Instance.AddHandleMillisecond(delayTimeMillisecond, () =>
                {
                    Execute(roleView);
                })
            );
        }

        protected virtual void Execute(RoleView roleView)
        {
            
        }
        public virtual void Update()
        { }
        
        protected virtual void FillNewInstance(SkillEffectBase newInstance)
        {
            newInstance.id = this.id;
            newInstance.delayTimeMillisecond = this.delayTimeMillisecond;
        }
    }
}