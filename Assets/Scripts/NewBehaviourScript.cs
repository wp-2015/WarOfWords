using System;
using Unity.VisualScripting;
using UnityEngine;
using WP;

public class NewBehaviourScript : MonoBehaviour
{
    public GamePipelineReplaceGUI actionGUI = new GamePipelineReplaceGUI();

    private void Awake()
    {
        GameEntry.Instance.Init();
    }

    public void Start()
    {
        GamePipelineManager.Instance.EnterPipeline(actionGUI);
    }

    private void OnGUI()
    {
        actionGUI.actionGUI?.Invoke();
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
}
