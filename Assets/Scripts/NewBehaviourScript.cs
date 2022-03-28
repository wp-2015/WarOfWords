using System;
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
    }
}
