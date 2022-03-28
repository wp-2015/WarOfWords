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

        Play,//释放技能
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
                {GamePipelineStep.Play, new GamePipelinePlay()},
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

        public void Update()
        {
            dicPipeline[currentPipeline].Update();
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

        public virtual void Update()
        {

        }
    }
}