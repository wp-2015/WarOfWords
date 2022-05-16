using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WP
{
    public class RoleIdleState : RoleState
    {
        public override void Enter()
        {
            base.Enter();
            EntityState = EntityState.RoleIdle;
            GameUtils.ShowLog(string.Format("我{0}现在可要待机了嗷, 摇起来", roleLogic.Name));
        }

        protected override void InitState()
        {
            canMove = true;
            canSkill = true;
        }
    }
}
