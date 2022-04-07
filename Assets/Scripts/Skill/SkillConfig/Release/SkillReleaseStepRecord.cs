using System;
using System.Threading;

namespace WP
{
    public class SkillReleaseStepRecord : PoolObj
    {
        public RoleView roleView;
        public SkillInfo skillInfo;
        public int stepIndex;

        public void Init(RoleView roleView, SkillInfo info)
        {
            stepIndex = 0;
            this.roleView = roleView;
            skillInfo = info;

            UpdateStep();
        }

        public void UpdateStep()
        {
            if (stepIndex >= skillInfo.lAllSkillShowStep.Count)
            {
                SkillRelaseEffectManager.Instance.FinishRelease(this);
            }
            else
            {
                var step = skillInfo.lAllSkillShowStep[stepIndex];
                var time = step.time;
                var effects = step.lAllSkillEffectInPlaying;
                foreach (var effect in effects)
                {
                    var delayTime = effect.delayTimeMillisecond;
                    TimeHandleManager.Instance.AddHandleMillisecond(delayTime, () =>
                    {
                        effect.Play(roleView);
                    });
                }
                
                TimeHandleManager.Instance.AddHandleSecond(time, () =>
                {
                    stepIndex++;
                    UpdateStep();
                });
            }
        }
    }
}