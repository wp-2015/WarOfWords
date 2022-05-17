using System.Collections.Generic;

namespace WP
{
    public class BuffHandle
    {
        private int iStepIndex;
        private SkillInfo skillInfo;
        private long stepTimeCount;
        private long preFrameTime;
        private RoleLogic roleLogic;
        private List<ulong> timeHandleIDs = new List<ulong>();

        public void Init(int buffID, RoleLogic roleLogic)
        {
            skillInfo = SkillManager.Instance.GetBuffInfo(buffID);
            this.roleLogic = roleLogic;
            iStepIndex = 0;
            stepTimeCount = 0;
            preFrameTime = GameUtils.GetNowMilliseconds();
            
            ExcuteCurrentIndex();
        }

        private void Over()
        {
            foreach (var id in timeHandleIDs)
            {
                TimeHandleManager.Instance.RemoveHandle(id);
            }
            roleLogic.RemoveBuff(this);
        }
    
        public void ExcuteCurrentIndex()
        {
            if (iStepIndex >= skillInfo.lAllSkillStep.Count)
            {
                Over();
            }
            else
            {
                var step = skillInfo.lAllSkillStep[iStepIndex];
                var effects = step.lAllSkillEffectInPlaying;
                foreach (var effect in effects)
                {
                    effect.Play(roleLogic.viewEntity);
                }

                var logics = step.lAllSkillLogicInPlaying;
                foreach (var logic in logics)
                {
                    logic.Play(roleLogic);
                }
            }
        }
        
        public void Update()
        {
            if (iStepIndex >= skillInfo.lAllSkillStep.Count)
            {
                Over();
                return;
            }
            var currentStep = skillInfo.lAllSkillStep[iStepIndex];
            var time = currentStep.time;
            var now = GameUtils.GetNowMilliseconds();
            stepTimeCount += now - preFrameTime;
            preFrameTime = now;
            if (stepTimeCount >= time)
            {
                iStepIndex++;
                stepTimeCount = 0;
                ExcuteCurrentIndex();
            }
        }
    }
}

