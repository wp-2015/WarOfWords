using System;
using Unity.VisualScripting;
using UnityEngine;
using WP.OtherConfig;

namespace WP
{
    public class RoleView : Entity
    {
        private RoleLogic roleLogic;
        public string Name { get; set; }
        private float fSpeed;

        private BodyInfo bodyInfo;
        public BodyInfo BodyInfo
        {
            get { return bodyInfo;}
            set
            {
                bodyInfo = value;
                SetStrength(value);
            }
        }

        private BodyInfo faceInfo;

        public BodyInfo FaceInfo
        {
            get { return faceInfo; }
            set
            {
                faceInfo = value;
                SetStrength(value);
            }
        }
        private BodyInfo voiceInfo;

        public BodyInfo VoiceInfo
        {
            get { return voiceInfo;}
            set
            {
                voiceInfo = value;
                SetStrength(value);
            }
        }
        private BodyInfo handInfo;

        public BodyInfo HandInfo
        {
            get { return handInfo;}
            set
            {
                handInfo = value;
                SetStrength(value);
            }
        }
        private BodyInfo footInfo;

        public BodyInfo FootInfo
        {
            get { return footInfo;}
            set
            {
                footInfo = value;
                SetStrength(value);
            }
        }

        private void SetStrength(BodyInfo bi)
        {
            UnityEngine.Random.InitState(DateTime.Now.Millisecond);
            var range = UnityEngine.Random.Range(0, bi.Tag.Length);
            string tag = bi.Tag[range];
            
            UnityEngine.Random.InitState(DateTime.Now.Millisecond);
            range = UnityEngine.Random.Range(0, bi.Des.Length);
            GameUtils.ShowLog(string.Format("{0}: {1}", tag, bi.Des[range]) );
        }

        public void SetLogic(RoleLogic roleLogic)
        {
            this.roleLogic = roleLogic;
            pos = roleLogic.pos;
            GameUtils.ShowLog(string.Format("我{0},初始位置在<{1}>了", Name, pos));
            fSpeed = GameCalculate.GetRoleSpeed(roleLogic);
        }

        public override void Update()
        {
            base.Update();
            var posL = roleLogic.pos;
            if (pos != posL)
            {
                if (Vector3.Distance(pos, posL) < fSpeed)
                {
                    pos = posL;
                }
                else
                {
                    var dir = (posL - pos).normalized;
                    pos = dir * fSpeed + pos;
                }
                GameUtils.ShowLog(string.Format("我{0},已经到了<{1}>了", Name, pos));
            }
        }
    }
}