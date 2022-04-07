using System.Collections.Generic;

namespace WP
{
    public class SkillRelaseEffectManager : Singleton_CSharp<SkillRelaseEffectManager>
    {
        private List<SkillReleaseStepRecord> lSkillReleaseStepRecord = new List<SkillReleaseStepRecord>();
        //释放技能
        public void Release(int skillID, RoleView roleView)
        {
            if (SkillEffectManager.Instance.dicSkillConfig.TryGetValue(skillID, out SkillInfo info))
            {
                var skillReleaseStepRecord = ObjectPool<SkillReleaseStepRecord>.Instance.Get();
                skillReleaseStepRecord.Init(roleView, info);
                var allSteps = info.lAllSkillShowStep;
                // foreach (var step in allSteps)
                // {
                //     var allEffects = step.lAllSkillEffectInPlaying;
                //     foreach (var effect in allEffects)
                //     {
                //         
                //     }
                // }
            }
        }

        public void FinishRelease(SkillReleaseStepRecord recode)
        {
            lSkillReleaseStepRecord.Remove(recode);
        }
    }
}