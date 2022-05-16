namespace WP
{
    public abstract class RoleState : BaseState
    {
        public RoleLogic roleLogic;
        public bool canMove;
        public bool canSkill;
        public bool isOver;
        protected abstract void InitState();

        public override void Enter()
        {
            base.Enter();
            isOver = false;
            InitState();
        }
    }
}