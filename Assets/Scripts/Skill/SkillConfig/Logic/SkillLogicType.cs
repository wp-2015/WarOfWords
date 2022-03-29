using UnityEngine;

namespace WP
{
    public enum SkillLogicType
    {
        Blink,//瞬移
        Damage,
    }

    public class SkillLogicBase
    {
    }

    public class BlinkSkillLogic : SkillLogicBase
    {
        public int dis;
    }

    public enum SkillDamageShape
    {
        Rect,
        Circle,
        Sector,//扇形
    }
    public class DamageSkillLogic : SkillLogicBase
    {
        public SkillDamageShape shape;
        public float fValue1;
        public float fValue2;
    }
}