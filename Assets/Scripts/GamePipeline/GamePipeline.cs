using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public class GamePipelineReplaceGUI
    {
        public Action actionGUI;
    }
    public enum GamePipelineStep
    {
        CreateName,//名字
        
        Face,//脸
        Voice,//嗓音
        Body,//身体
        Hand,//手
        Foot,//脚
        
        CreateRole,//根据以上创建角色
    }
    //规范游戏流程
    //1、创建角色。2、挑选身体的部件。3、释放技能演示
    public class GamePipelineManager : Singleton_CSharp<GamePipelineManager>
    {
        public string name = "张三";
        public int faceStrength = 50;
        public int voiceStrength = 50;
        public int bodyStrength = 50;
        public int handStrength = 50;
        public int footStrength = 50;
        
        private GamePipelineStep currentPipeline;

        private Dictionary<GamePipelineStep, GamePipelineBase> dicPipeline =
            new Dictionary<GamePipelineStep, GamePipelineBase>()
            {
                {GamePipelineStep.CreateName, new GamePipelineCreateName()},
                {GamePipelineStep.Face, new GamePipelineFace()},
                {GamePipelineStep.Voice, new GamePipelineVoice()},
                {GamePipelineStep.Body, new GamePipelineBody()},
                {GamePipelineStep.Hand, new GamePipelineHand()},
                {GamePipelineStep.Foot, new GamePipelineFoot()},
                {GamePipelineStep.CreateRole, new GamePipelineCreateRole()},
            };

        public void EnterPipeline()
        {
            dicPipeline[currentPipeline].Enter();
        }

        public void UpdatePipeline()
        {
            dicPipeline[currentPipeline++].Leave();
            dicPipeline[currentPipeline].Enter();
        }
    }

    public class GamePipelineBase
    {
        public virtual void Enter()
        {
            UIManager.Instance.cbShow = Draw;
        }

        public virtual void Draw()
        {
        }

        public virtual void Leave()
        {
            if(UIManager.Instance.cbShow == Draw)
            {
                UIManager.Instance.cbShow = null;
            }
        }
    }

    public class GamePipelineFace : GamePipelineBase
    {
        public override void Draw()
        {
            GUILayout.Label("创建脸部");
            GamePipelineManager.Instance.faceStrength = (int)GUILayout.HorizontalSlider(
                (float)GamePipelineManager.Instance.faceStrength,
                0f, GameConst.MaxStrength);
            if (GUILayout.Button("创建脸部完毕"))
            {
                GamePipelineManager.Instance.UpdatePipeline();
            }
        }
    }
    public class GamePipelineCreateName : GamePipelineBase
    {
        public override void Draw()
        {
            GUILayout.Label("请输入名字");
            GamePipelineManager.Instance.name = GUILayout.TextField(GamePipelineManager.Instance.name);
            if (GUILayout.Button("创建名字完毕"))
            {
                GamePipelineManager.Instance.UpdatePipeline();
            }
        }
    }
    public class GamePipelineBody : GamePipelineBase
    {
        public override void Draw()
        {
            GUILayout.Label("创建身体");
            GamePipelineManager.Instance.bodyStrength = (int)GUILayout.HorizontalSlider(
                (float)GamePipelineManager.Instance.bodyStrength,
                0f, GameConst.MaxStrength);
            if (GUILayout.Button("创建身体完毕"))
            {
                GamePipelineManager.Instance.UpdatePipeline();
            }
        }
    }
    public class GamePipelineVoice : GamePipelineBase
    {
        public override void Draw()
        {
            GUILayout.Label("创建声线");
            GamePipelineManager.Instance.voiceStrength = (int)GUILayout.HorizontalSlider(
                (float)GamePipelineManager.Instance.voiceStrength,
                0f, GameConst.MaxStrength);
            if (GUILayout.Button("创建声线完毕"))
            {
                GamePipelineManager.Instance.UpdatePipeline();
            }
        }
    }
    public class GamePipelineHand : GamePipelineBase
    {
        public override void Draw()
        {
            GUILayout.Label("创建手部");
            GamePipelineManager.Instance.handStrength = (int)GUILayout.HorizontalSlider(
                (float)GamePipelineManager.Instance.handStrength,
                0f, GameConst.MaxStrength);
            if (GUILayout.Button("创建手部完毕"))
            {
                GamePipelineManager.Instance.UpdatePipeline();
            }
        }
    }
    public class GamePipelineFoot : GamePipelineBase
    {
        public override void Draw()
        {
            GUILayout.Label("创建脚部");
            GamePipelineManager.Instance.footStrength = (int)GUILayout.HorizontalSlider(
                (float)GamePipelineManager.Instance.footStrength,
                0f, GameConst.MaxStrength);
            if (GUILayout.Button("创建脚部完毕"))
            {
                GamePipelineManager.Instance.UpdatePipeline();
            }
        }
    }

    public class GamePipelineCreateRole : GamePipelineBase
    {
        public override void Enter()
        {
            var pipeline = GamePipelineManager.Instance;
            string szLog = string.Format("嘿, 你刚刚创建一个角色的数据，他叫:{0}, 脸部:{1}, 声线:{2}, 身体:{3}, 手部:{4}, 脚:{5}。下面我们将会创建这个角色!",
                pipeline.name, pipeline.faceStrength, pipeline.voiceStrength, pipeline.bodyStrength, 
                pipeline.handStrength, pipeline.footStrength);
            GameUtils.ShowLog(szLog);
            
            var role = EntityManager.Instance.MakeEntity<RoleLogic>();
            GameAllInfo.SelfRole = role;
            GameUtils.ShowLog("下面我来自我介绍一下");
            role.Name = pipeline.name;
            role.BodyStrength = pipeline.bodyStrength;
            role.FaceStrength = pipeline.faceStrength;
            role.VoiceStrength = pipeline.voiceStrength;
            role.HandStrength = pipeline.handStrength;
            role.FootStrength = pipeline.footStrength;
        }
    }
}