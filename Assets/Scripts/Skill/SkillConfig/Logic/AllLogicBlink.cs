using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public class BlinkLogicHandle : ITimeHandleUpdate
    {
        private RoleLogic roleLogic;
        private Vector3 v3Dis;
        private float fTimeCounter = 0;
        private long fTimeRecord;
        private float fTotalTime;
        private Vector3 v3Destination;

        private ulong id;
        public void Init(float time, Vector3 dis, RoleLogic roleLogic)
        {
            fTimeCounter = 0;
            this.roleLogic = roleLogic;
            v3Dis = dis;
            v3Destination = roleLogic.pos + v3Dis;
            fTotalTime = time;
            fTimeRecord = GameUtils.GetNowMilliseconds();
            id = TimeHandleManager.Instance.AddUpdateHandle(this);
            GameUtils.ShowLog(String.Format("{0}:报告,我将在{1}毫秒内,移动到{2}的位置", 
                roleLogic.Name, time, v3Destination));
        }

        public void Update()
        {
            var now = GameUtils.GetNowMilliseconds();
            var timeSpeed = now - fTimeRecord;
            fTimeRecord = now;
            if (timeSpeed > fTotalTime)
            {
                roleLogic.pos = v3Destination;
                GameUtils.ShowLog(String.Format("{0}:报告,我已到达{1}", 
                    roleLogic.Name, v3Destination));
                TimeHandleManager.Instance.RemoveUpdateHandle(id);
                return;
            }
            roleLogic.pos += (float)timeSpeed / fTotalTime * v3Dis;
            fTimeCounter += timeSpeed;
            if (fTimeCounter >= fTotalTime)
            {
                roleLogic.pos = v3Destination;
                GameUtils.ShowLog(String.Format("{0}:报告,我已到达{1}", 
                    roleLogic.Name, v3Destination));
                TimeHandleManager.Instance.RemoveUpdateHandle(id);
            }
        }
    }
    [Serializable]
    public class BlinkSkillLogic : SkillLogicBase
    {
        public Vector3 dis;
        public float time;//位移需要的时间

        protected override void Execute(RoleLogic roleLogic)
        {
            base.Execute(roleLogic);
            roleLogic.pos = roleLogic.pos + dis;
        }

        public override void Play(RoleLogic roleLogic)
        {
            var updateHandle = new BlinkLogicHandle();
            updateHandle.Init(time, dis, roleLogic);
        }
    }
    
    [CreateAssetMenu(fileName = "AllLogicBlink", menuName = "CustomConfig/AllLogicBlink")]
    public class AllLogicBlink : ScriptableObject
    {
        public List<BlinkSkillLogic> lAllSkill = new List<BlinkSkillLogic>();
    }
}