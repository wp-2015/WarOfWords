using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using WP;

public class NewBehaviourScript : MonoBehaviour
{
    private void Awake()
    {
        GameEntry.Instance.Init();
    }

    public void Start()
    {
        GamePipelineManager.Instance.EnterPipeline();
        //Debug.Log(string.Format("<color=red>{0}</color>, <color=red>{1}</color>", 1,3));
        
        // GameUtils.ShowLog(string.Format("只见<color=red>{0}</color>用<color=red>{1}</color>摆出一副<color=red>{2}</color>的架势", 
        //     1, 2, 3));
    }

    private void OnGUI()
    {
        UIManager.Instance.cbShow?.Invoke();
        // if(GUILayout.Button("创建主角"))
        // {
        //     GameEntry.Instance.MakeRole();
        // }
        //
        // if (GUILayout.Button("释放技能"))
        // {
        //     
        // }
    }

    private void Update()
    {
        GamePipelineManager.Instance.Update();
        GameEntry.Instance.Update();
        TimeHandleManager.Instance.Update();
    }
}
