namespace WP
{
    public class SkillLogic
    {
        
    }
    
    public class SkillLogicBase : SkillStepCellBase
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