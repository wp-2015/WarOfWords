using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WP
{
    public class MoveStateUpdateInput : RoleState
    {
        public KeyCode InputKeyCode = KeyCode.None;

        private float speed;
        public override void Enter()
        {
            base.Enter();
            EntityState = EntityState.MoveUpdateInput;
            var strength = roleLogic.FootStrength;
            speed = GameCalculate.GetRoleSpeed(roleLogic);
            GameCalculate.MoveCalculate(roleLogic, InputKeyCode, speed);
        }

        protected override void InitState()
        {
            canMove = true;
            canSkill = true;
        }

        public override void Update()
        {
            base.Update();
            GameCalculate.MoveCalculate(roleLogic, InputKeyCode, speed);
        }

        public override void Leave()
        {
            ObjectPool<MoveStateUpdateInput>.Instance.Release(this);
        }
    }
}