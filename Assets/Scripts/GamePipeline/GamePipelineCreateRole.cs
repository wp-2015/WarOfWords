using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace WP
{

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
            

            if (GUILayout.Button("随机创建"))
            {
                UnityEngine.Random.InitState(DateTime.Now.Millisecond);
                GamePipelineManager.Instance.name = "张三";
                GamePipelineManager.Instance.faceStrength = UnityEngine.Random.Range(0, GameConst.MaxStrength);
                GamePipelineManager.Instance.voiceStrength = UnityEngine.Random.Range(0, GameConst.MaxStrength);
                GamePipelineManager.Instance.bodyStrength = UnityEngine.Random.Range(0, GameConst.MaxStrength);
                GamePipelineManager.Instance.handStrength = UnityEngine.Random.Range(0, GameConst.MaxStrength);
                GamePipelineManager.Instance.footStrength = UnityEngine.Random.Range(0, GameConst.MaxStrength);
                GamePipelineManager.Instance.JumpToTargetPipeline(GamePipelineStep.CreateRole);
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
            role.Name = pipeline.name;
            role.BodyStrength = pipeline.bodyStrength;
            role.FaceStrength = pipeline.faceStrength;
            role.VoiceStrength = pipeline.voiceStrength;
            role.HandStrength = pipeline.handStrength;
            role.FootStrength = pipeline.footStrength;
            role.Ready();
            GameAllInfo.SelfRole = role;
            GamePipelineManager.Instance.UpdatePipeline();
        }
    }
}
