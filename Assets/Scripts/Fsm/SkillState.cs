using System;
using UnityEngine;

namespace WP
{
    public class SkillState : RoleState
    {
        public int SkillID;
        
        private int iStepIndex;
        private SkillInfo skillInfo;
        private int stepTimeCount;
        private int preFrameTime;
        public override void Enter()
        {
            base.Enter();
            EntityState = EntityState.Skilling;
            GameUtils.ShowLog(String.Format("我{0}要释放{1}技能了可！", roleLogic.Name, SkillID));

            skillInfo = SkillManager.Instance.GetSkillInfo(SkillID);
            iStepIndex = 0;
            stepTimeCount = 0;
            preFrameTime = GetNowTime();
            ExcuteCurrentIndex();
        }

        private int GetNowTime()
        {
            return DateTime.Now.Millisecond;
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
            var now = GetNowTime();
            stepTimeCount += now - preFrameTime;
            preFrameTime = now;
            if (stepTimeCount >= time)
            {
                iStepIndex++;
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