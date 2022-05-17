using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public class SkillManager : Singleton_CSharp<SkillManager>
    {
        public Dictionary<int, SkillInfo> dicSkillConfig = new Dictionary<int, SkillInfo>();
        public Dictionary<int, SkillInfo> dicBuffConfig = new Dictionary<int, SkillInfo>();

        
        public void LoadConfig()
        {
            var dicAllEffects = LoadEffects();
            var dicAllLogics = LoadLogics();
            var skillConfig = GameUtils.LoadAsset<SkillConfig>(GameConst.SkillConfig);
            var buffConfig = GameUtils.LoadAsset<SkillConfig>(GameConst.BuffConfig);
            LoadSkillConfig(dicAllLogics, dicAllEffects, dicSkillConfig, skillConfig);
            LoadSkillConfig(dicAllLogics, dicAllEffects, dicBuffConfig, buffConfig);
        }
        public void LoadSkillConfig(Dictionary<SkillLogicType, Dictionary<int, SkillLogicBase>> dicAllLogics,
        Dictionary<SkillEffectType, Dictionary<int, SkillEffectBase>> dicAllEffects,
        Dictionary<int, SkillInfo> dicSkillConfig, SkillConfig skillConfig)
        {
            //var skillConfig = GameUtils.LoadAsset<SkillConfig>(GameConst.SkillConfig);
            var allSkillInfo = skillConfig.lAllSkill;
            foreach(var skillInfo in allSkillInfo)
            {
                var id = skillInfo.id;
                if(dicSkillConfig.ContainsKey(id))
                {
                    Debug.LogError(string.Format("技能重复ID：{0}", id));
                    continue;
                }
                dicSkillConfig.Add(id, skillInfo);
                var skillSteps = skillInfo.lAllSkillStep;
                foreach(var step in skillSteps)
                {
                    var effectBases = step.lEffectsInSaving;
                    var effects = step.lAllSkillEffectInPlaying;
                    effects.Clear();
                    foreach(var effectBase in effectBases)
                    {
                        var type = effectBase.type;
                        var effectId = effectBase.id;
                        if (dicAllEffects.TryGetValue(type, out Dictionary<int, SkillEffectBase> temp))
                        {
                            if (temp.TryGetValue(effectId, out SkillEffectBase effect))
                                effects.Add(effect);
                            else
                                Debug.LogError(string.Format("没有找到{0}类型的{1}技能", type, effectId));
                        }
                        else
                            Debug.LogError(string.Format("没有找到{0}类型的技能", type));
                    }
                    var logicBases = step.lLogicsInSaving;
                    var logics = step.lAllSkillLogicInPlaying;
                    logics.Clear();
                    foreach (var logicBase in logicBases)
                    {
                        var type = logicBase.type;
                        var logicID = logicBase.id;
                        if (dicAllLogics.TryGetValue(type, out Dictionary<int, SkillLogicBase> temp))
                        {
                            if(temp.TryGetValue(logicID, out SkillLogicBase logic))
                                logics.Add(logic);
                            else
                                Debug.LogError(string.Format("没有找到{0}类型的{1}技能", type, logicID));
                        }
                        else
                            Debug.LogError(string.Format("没有找到{0}类型的技能", type));
                    }
                }
            }
        }
        
        public SkillInfo GetSkillInfo(int id)
        {
            if(dicSkillConfig.TryGetValue(id, out SkillInfo res))
                return res;
            return null;
        }

        public SkillInfo GetBuffInfo(int id)
        {
            if(dicBuffConfig.TryGetValue(id, out SkillInfo res))
                return res;
            return null;
        }

        private Dictionary<SkillLogicType, Dictionary<int, SkillLogicBase>> LoadLogics()
        {
            Dictionary<SkillLogicType, Dictionary<int, SkillLogicBase>> dicAllLogics =
                new Dictionary<SkillLogicType, Dictionary<int, SkillLogicBase>>();
            var logics = GameUtils.LoadAsset<AllLogicBlink>(GameConst.AllLogicBlink);
            var dicLogics = new Dictionary<int, SkillLogicBase>(logics.lAllSkill.Count); 
            foreach(var logic in logics.lAllSkill)
            {
                dicLogics[logic.id] = logic;
            }
            dicAllLogics[SkillLogicType.Blink] = dicLogics;

            var damageLogics = GameUtils.LoadAsset<AllLogicDamage>(GameConst.AllLogicDamage);
            dicLogics = new Dictionary<int, SkillLogicBase>(damageLogics.lAllSkill.Count); 
            foreach(var logic in damageLogics.lAllSkill)
            {
                dicLogics[logic.id] = logic;
            }
            dicAllLogics[SkillLogicType.Damage] = dicLogics;
            
            return dicAllLogics;
        }

        private Dictionary<SkillEffectType, Dictionary<int, SkillEffectBase>> LoadEffects()
        {
            Dictionary<SkillEffectType, Dictionary<int, SkillEffectBase>> dicAllEffects = 
                new Dictionary<SkillEffectType, Dictionary<int, SkillEffectBase>>();
            var effects = GameUtils.LoadAsset<AllEffectSkillEffect>(GameConst.AllEffectSkillEffect);
            var dicEffects = new Dictionary<int, SkillEffectBase>(effects.lAllSkill.Count);
            foreach(var effect in effects.lAllSkill)
            {
                dicEffects[effect.id] = effect;
            }
            dicAllEffects[SkillEffectType.Effect] = dicEffects;

            var anis = GameUtils.LoadAsset<AllAnimationSkillEffect>(GameConst.AllAnimationSkillEffect);
            dicEffects = new Dictionary<int, SkillEffectBase>(anis.lAllSkill.Count);
            foreach (var effect in anis.lAllSkill)
            {
                dicEffects[effect.id] = effect;
            }
            dicAllEffects[SkillEffectType.Animation] = dicEffects;

            var audios = GameUtils.LoadAsset<AllAudioSkillEffect>(GameConst.AllAudioSkillEffect);
            dicEffects = new Dictionary<int, SkillEffectBase>(audios.lAllSkill.Count);
            foreach (var effect in audios.lAllSkill)
            {
                dicEffects[effect.id] = effect;
            }
            dicAllEffects[SkillEffectType.AudioPlay] = dicEffects;
            return dicAllEffects;
        }
    }
}