using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public class RoleLogic : Entity
    {
        private int bodyStrength;
        public int BodyStrength
        {
            get { return bodyStrength; }
            set
            {
                bodyStrength = value;
                var bc = BodyConfigManager.Instance.bodyConfig;
                var level = GetStrengetStep(bc, value);
                viewEntity.BodyInfo = bc.lc[level];
            }
        }

        private int faceStrength;

        public int FaceStrength
        {
            get { return faceStrength;}
            set
            {
                faceStrength = value;
                var bc = BodyConfigManager.Instance.faceConfig;
                var level = GetStrengetStep(bc, value);
                viewEntity.FaceInfo = bc.lc[level];
            }
        }

        //嗓音
        private int voiceStrength;

        public int VoiceStrength
        {
            get { return voiceStrength; }
            set
            {
                voiceStrength = value;
                var bc = BodyConfigManager.Instance.voiceConfig;
                var level = GetStrengetStep(bc, value);
                viewEntity.VoiceInfo = bc.lc[level];
            }
        }

        private int handStrength;

        public int HandStrength
        {
            get { return handStrength; }
            set
            {
                handStrength = value;
                var bc = BodyConfigManager.Instance.handConfig;
                var level = GetStrengetStep(bc, value);
                viewEntity.HandInfo = bc.lc[level];
            }
        }

        private int footStrength;

        public int FootStrength
        {
            get { return footStrength; }
            set
            {
                footStrength = value;
                var bc = BodyConfigManager.Instance.footConfig;
                var level = GetStrengetStep(bc, value);
                viewEntity.FootInfo = bc.lc[level];
            }
        }

        public string Name
        {
            set
            {
                viewEntity.Name = value;
                GameUtils.ShowLog(string.Format("我叫{0}", Name));
            }
            get
            {
                return viewEntity.Name;
            }
        }
        
        public RoleView viewEntity;
        //TODO:当被打断技能时候，需要把逻辑和表现队列中的已经排序需要做的事情清空
        public List<ulong> lTimeEventToDo = new List<ulong>();

        public void AddTimeEventToDo(ulong id)
        {
            lTimeEventToDo.Add(id);
        }


        public List<BuffHandle> lWaitToMoveBuff = new List<BuffHandle>();
        public List<BuffHandle> lBuffs = new List<BuffHandle>();
        public void AddBuff(int buffID)
        {
            BuffHandle bh = new BuffHandle();
            lBuffs.Add(bh);
            bh.Init(buffID, this);
        }

        public void RemoveBuff(BuffHandle buff)
        {
            lWaitToMoveBuff.Add(buff);
        }

        public override void Init(long id)
        {
            base.Init(id);
            GameUtils.ShowLog(string.Format("我是一个Role, 我出生了, 我是第{0}个出生的实体", id));
            viewEntity = EntityManager.Instance.MakeEntity<RoleView>();
            viewEntity.lTimeEventToDO.Clear();
            lTimeEventToDo.Clear();
        }

        public override void Update()
        {
            base.Update();
            viewEntity.Update();

            foreach (var buffHandle in lBuffs)
            {
                buffHandle.Update();
            }

            if (lWaitToMoveBuff.Count > 0)
            {
                foreach (var buffHandle in lWaitToMoveBuff)
                {
                    lBuffs.Remove(buffHandle);
                }
                lWaitToMoveBuff.Clear();
            }
        }

        public override void Relase()
        {
            base.Relase();
            if (null == viewEntity)
            {
                Debug.LogError( string.Format("正在回收一个没有表现层的逻辑实例, 逻辑实例ID:{0}", id));
                return;
            }
            EntityManager.Instance.Release<RoleView>(viewEntity);
        }

        //属性设置完毕，开始进入Idle状态
        public void Ready()
        {
            viewEntity.SetLogic(this);
            var idle = ObjectPool<RoleIdleState>.Instance.Get();
            idle.roleLogic = this;
            State = idle;
        }

        public int GetStrengetStep(BodyConfig bc, int strength)
        {
            var lc = bc.lc;
            for (int i = 0; i < lc.Count; i++)
            {
                if (strength >= lc[i].Strength)
                {
                    return i;
                }
            }
            return lc.Count - 1;
        }
    }
}
