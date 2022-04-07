using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    [Serializable]
    public class SkillEffectBase
    {
        public RoleView roleView;
        public int id;
        public int delayTimeMillisecond;
        
        public virtual void Play(RoleView roleView)
        { }
        public virtual void Update()
        { }
    }
}