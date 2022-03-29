using System;

namespace WP
{
    public class SkillState : RoleState
    {
        public int SkillID;
        public override void Enter()
        {
            GameUtils.ShowLog(String.Format("我{0}要释放{1}技能了可！", roleLogic.Name, SkillID));
        }

        public override void Update()
        {

        }

        public override void Leave()
        {
            
        }

        public override void FixedUpdate()
        {

        }
    }
}