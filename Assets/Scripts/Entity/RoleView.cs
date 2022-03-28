using System;
using Unity.VisualScripting;
using WP.OtherConfig;

namespace WP
{
    public class RoleView : Entity
    {
        public string Name { get; set; }

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
            get { return bodyInfo;}
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
        
        public override void Init(long id)
        {
            base.Init(id);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}