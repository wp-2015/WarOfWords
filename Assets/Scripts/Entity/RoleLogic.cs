using UnityEngine;
using Utils;

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
                var bc = GameConfigs.bodyConfig;
                var level = GameUtils.GetStrengetStep(bc, value);
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
                var bc = GameConfigs.faceConfig;
                var level = GameUtils.GetStrengetStep(bc, value);
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
                var bc = GameConfigs.voiceConfig;
                var level = GameUtils.GetStrengetStep(bc, value);
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
                var bc = GameConfigs.handConfig;
                var level = GameUtils.GetStrengetStep(bc, value);
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
                var bc = GameConfigs.footConfig;
                var level = GameUtils.GetStrengetStep(bc, value);
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
        public override void Init(long id)
        {
            base.Init(id);
            GameUtils.ShowLog(string.Format("我是一个Role, 我出生了, 我是第{0}个出生的实体", id));
            viewEntity = EntityManager.Instance.MakeEntity<RoleView>();
        }

        public virtual void Update()
        {
            base.Update();
            viewEntity.Update();
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
    }
}
