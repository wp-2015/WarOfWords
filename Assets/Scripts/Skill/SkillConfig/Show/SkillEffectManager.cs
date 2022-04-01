using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public class SkillEffectManager : Singleton_CSharp<SkillEffectManager>
    {
        public Dictionary<int, SkillInfo> dicSkillConfig = new Dictionary<int, SkillInfo>();

        public void LoadConfig()
        {
            var dicAllEffects = LoadEffects();

            var skillConfig = GameUtils.LoadAsset<SkillShowConfig>(GameConst.SkillShowConfig);
            var allSkillInfo = skillConfig.lAllSkill;
            foreach(var skillInfo in allSkillInfo)
            {
                var id = skillInfo.id;
                if(dicSkillConfig.TryGetValue(id, out SkillInfo res))
                {
                    Debug.LogError(string.Format("技能重复ID：{0}", id));
                    continue;
                }
                dicSkillConfig.Add(id, res);
                var skillSteps = skillInfo.lAllSkillShowStep;
                foreach(var step in skillSteps)
                {
                    var effectBases = step.lEffectsInSaving;
                    var effects = step.lAllSkillEffectInPlaying;
                    foreach(var effectBase in effectBases)
                    {
                        var type = effectBase.type;
                        var effectId = effectBase.id;
                        if (dicAllEffects.TryGetValue(type, out Dictionary<int, SkillEffectBase> temp))
                        {
                            if (temp.TryGetValue(effectId, out SkillEffectBase effect))
                                step.lAllSkillEffectInPlaying.Add(effect);
                            else
                                Debug.LogError(string.Format("没有找到{0}类型的{1}技能", type, effectId));
                        }
                        else
                            Debug.LogError(string.Format("没有找到{0}类型的技能", type));
                    }
                }
            }
        }

        public Dictionary<SkillEffectType, Dictionary<int, SkillEffectBase>> LoadEffects()
        {
            Dictionary<SkillEffectType, Dictionary<int, SkillEffectBase>> dicAllEffects = new Dictionary<SkillEffectType, Dictionary<int, SkillEffectBase>>();
            var effects = GameUtils.LoadAsset<AllEffectSkillEffect>(GameConst.AllEffectSkillEffect);
            var dicEffects = new Dictionary<int, SkillEffectBase>(effects.lAllSkill.Count);
            foreach(var effect in effects.lAllSkill)
            {
                dicEffects[effect.id] = effect;
            }
            dicAllEffects[SkillEffectType.Effect] = dicEffects;

            var anis = GameUtils.LoadAsset<AllEffectSkillEffect>(GameConst.AllAnimationSkillEffect);
            dicEffects = new Dictionary<int, SkillEffectBase>(anis.lAllSkill.Count);
            foreach (var effect in anis.lAllSkill)
            {
                dicEffects[effect.id] = effect;
            }
            dicAllEffects[SkillEffectType.Animation] = dicEffects;

            var audios = GameUtils.LoadAsset<AllEffectSkillEffect>(GameConst.AllAudioSkillEffect);
            dicEffects = new Dictionary<int, SkillEffectBase>(audios.lAllSkill.Count);
            foreach (var effect in anis.lAllSkill)
            {
                dicEffects[effect.id] = effect;
            }
            dicAllEffects[SkillEffectType.AudioPlay] = dicEffects;
            return dicAllEffects;
        }
    }
}