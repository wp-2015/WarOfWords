using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public class SkillStepCellBase
    {
        public int delayTimeMillisecond;
        // public int delayTimeStartMillisecond;
        //
        // public void Init()
        // {
        //     delayTimeStartMillisecond = GameUtils.GetNowMillisecond();
        // }
        //
        // public void Update()
        // {
        //     if(GameUtils.GetNowMillisecond() - delayTimeStartMillisecond < delayTimeMillisecond)
        //         Play();
        // }
        //
        // public void Play()
        // {
        // }
        public virtual void Enter()
        { }
        public virtual void Update()
        { }
    }
}