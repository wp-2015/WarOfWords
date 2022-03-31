using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using WP;

public class SkillEditor : EditorWindow
{
    [MenuItem("Tools/SkillEditor", false, 1)]
    static void OpenWindow()
    {
        var window = GetWindow<SkillEditor>(false, "SkillEditor");
        if (window.position.position == Vector2.zero)
        {
            Resolution res = Screen.currentResolution;
        }
        window.position = new Rect(100, 20, 400, 700);
        window.Show();
    }

    private SkillShowConfig skillShowConfig;
    private AllAudioSkillEffect allAudioSkillEffect;
    private AllAnimationSkillEffect allAnimationSkillEffect;
    private AllEffectSkillEffect allEffectSkillEffect;
    private void OnEnable()
    {
        skillShowConfig = AssetDatabase.LoadAssetAtPath<SkillShowConfig>("Assets/Resources/SkillConfig/SkillShow/SkillShowConfig.asset");
        allAudioSkillEffect = AssetDatabase.LoadAssetAtPath<AllAudioSkillEffect>("Assets/Resources/SkillConfig/SkillShow/AllAudioSkillEffect.asset");
        allAnimationSkillEffect = AssetDatabase.LoadAssetAtPath<AllAnimationSkillEffect>("Assets/Resources/SkillConfig/AllSkillShow/AnimationSkillEffect.asset");
        allEffectSkillEffect = AssetDatabase.LoadAssetAtPath<AllEffectSkillEffect>("Assets/Resources/SkillConfig/SkillShow/AllEffectSkillEffect.asset");
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical(GUILayout.Width(166));
        if (GUILayout.Button("+添加新技能+"))
        {
            
        }
        GUILayout.EndVertical();
        
        GUILayout.BeginVertical(GUILayout.Width(266));
        ShowSkill(0);
        GUILayout.EndVertical();
        
        GUILayout.BeginVertical(GUILayout.Width(166));
        if (GUILayout.Button("+添加效果+"))
        {
            
        }
        GUILayout.EndVertical();
        
        GUILayout.BeginVertical(GUILayout.Width(266));
        ShowEffect(0);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }

    private void ShowSkill(int id)
    {
        GUILayout.Label("这里显示技能");
    }

    private SkillEffectType skillEffectType;
    private int skillEffectID = 0;
    private void ShowEffect(int id)
    {
        if (id <= 0)
        {
            GUILayout.BeginHorizontal();
            skillEffectType = (SkillEffectType) EditorGUILayout.EnumPopup(skillEffectType);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("特效ID:");
            skillEffectID = EditorGUILayout.IntField(skillEffectID);
            GUILayout.EndHorizontal();
            if (skillEffectType == SkillEffectType.Animation)
            {
                ShowAnimationEffect();
            }
            else if (skillEffectType == SkillEffectType.Effect)
            {
                ShowEffectAdd();
            }
            else if (skillEffectType == SkillEffectType.AudioPlay)
            {
                ShowAudioEffect();
            }
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("添加"))
            {
                AddEffectConfig();
            }
            GUILayout.EndHorizontal();
        }
        else
        {
            
            
            if (GUILayout.Button("保存"))
            {
            
            }
        }
    }

    private void AddEffectConfig()
    {
        if (skillEffectType == SkillEffectType.AudioPlay)
        {
            var res = new AudioSkillEffect();
            res.audioName = audioName;
            allAudioSkillEffect.lAllSkill.Add(res);
            res.id = skillEffectID;
            EditorUtility.SetDirty(allAudioSkillEffect);
        }
        else if (skillEffectType == SkillEffectType.Animation)
        {
            var res = new AnimationSkillEffect();
            res.aniName = animationName;
            allAnimationSkillEffect.lAllSkill.Add(res);
            res.id = skillEffectID;
            EditorUtility.SetDirty(allAnimationSkillEffect);
        }
        else if (skillEffectType == SkillEffectType.Effect)
        {
            var res = new EffectSkillEffect();
            res.prefabPath = effectName;
            res.bIsWorld = isWorld;
            allEffectSkillEffect.lAllSkill.Add(res);
            res.id = skillEffectID;
            EditorUtility.SetDirty(allEffectSkillEffect);
        }
    }

    private string animationName = "";
    private void ShowAnimationEffect()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("动作名字", GUILayout.Width(66));
        animationName = GUILayout.TextField(animationName);
        GUILayout.EndHorizontal();
    }

    private string audioName = "";
    private void ShowAudioEffect()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("音效名字", GUILayout.Width(66));
        audioName = GUILayout.TextField(audioName);
        GUILayout.EndHorizontal();
    }

    private string effectName = "";
    private bool isWorld = false;
    private void ShowEffectAdd()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("特效名字", GUILayout.Width(66));
        effectName = GUILayout.TextField(effectName);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        isWorld = GUILayout.Toggle(isWorld, "是否世界坐标");
        GUILayout.EndHorizontal();
    }
}
