using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WP
{
    public class MoveStateUpdateInput : BaseState
    {
        public RoleLogic roleLogic;
        public KeyCode firstHandleInput = KeyCode.None;

        private float speed;
        public override void Enter()
        {
            var strength = roleLogic.FootStrength;
            speed = strength / (GameConst.MaxStrength + 1);
        }

        public override void FixedUpdate()
        {

        }

        public override void Leave()
        {
            ObjectPool<MoveStateUpdateInput>.Instance.Release(this);
        }

        public override void Update()
        {
            var pos = roleLogic.pos;
            if (InputManager.CheckSkillKey() != KeyCode.None)
            {

            }
            else if (InputManager.CheckMoveKey() != KeyCode.None)
            {
                GameCalculate.MoveCalculate(roleLogic, InputManager.CheckMoveKey(), speed);
            }
            else
            {
                var idle = ObjectPool<RoleIdleState>.Instance.Get();
                idle.roleLogic = roleLogic;
                roleLogic.State = idle;
            }    

        }
    }
}