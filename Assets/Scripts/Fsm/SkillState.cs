using System;
using UnityEngine;

namespace WP
{
    public class SkillState : RoleState
    {
        public int SkillID;
        
        private int iStepIndex;
        private SkillInfo skillInfo;
        private long stepTimeCount;
        private long preFrameTime;
        public override void Enter()
        {
            base.Enter();
            EntityState = EntityState.Skilling;
            skillInfo = SkillManager.Instance.GetSkillInfo(SkillID);
            GameUtils.ShowLog(String.Format("{0}:看我一招{1}", roleLogic.Name, skillInfo.name));
            iStepIndex = 0;
            stepTimeCount = 0;
            preFrameTime = GameUtils.GetNowMilliseconds();
            ExcuteCurrentIndex();
        }

        public void ExcuteCurrentIndex()
        {
            if (iStepIndex >= skillInfo.lAllSkillStep.Count)
            {
                isOver = true;
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

        public override void Update()
        {
            if(isOver || iStepIndex >= skillInfo.lAllSkillStep.Count)
                return;
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

        public override void Leave()
        {
            
        }

        public override void FixedUpdate()
        {

        }
        

        protected override void InitState()
        {
            canMove = false;
            canSkill = false;
        }
    }
}