using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public abstract class SkillEffectBase
    {
        public int delayTimeMillisecond;
        public int delayTimeStartMillisecond;

        public void Init()
        {
            delayTimeStartMillisecond = GameUtils.GetNowMillisecond();
        }

        public void Update()
        {
            if(GameUtils.GetNowMillisecond() - delayTimeStartMillisecond < delayTimeMillisecond)
                Play();
        }

        public abstract void Play();
    }
}