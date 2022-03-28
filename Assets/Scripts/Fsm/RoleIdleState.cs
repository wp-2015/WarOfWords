using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP
{
    public class RoleIdleState : BaseState
    {
        public RoleLogic roleLogic;
        public override void Enter()
        {
            GameUtils.ShowLog(string.Format("我{0}现在可要待机了嗷, 摇起来", roleLogic.Name));
        }
    }
}
