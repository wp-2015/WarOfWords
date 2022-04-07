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
        
    }

}
