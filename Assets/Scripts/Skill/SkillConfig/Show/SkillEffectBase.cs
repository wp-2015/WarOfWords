using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    [Serializable]
    public class SkillEffectBase : SkillStepCellBase
    {
        public SkillEffectType type;
        public int id;
    }
}