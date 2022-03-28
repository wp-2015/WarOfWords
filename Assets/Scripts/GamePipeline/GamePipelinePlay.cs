using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WP
{
    public class GamePipelinePlay : GamePipelineBase
    {
        public override void Draw()
        {
            GUILayout.Label("WASD:移动");
        }

        public override void Update()
        {
            base.Update();
            var keyCode = InputManager.CheckMoveKey();
            if(keyCode != KeyCode.None)
            {
                var moveState = ObjectPool<MoveStateUpdateInput>.Instance.Get();
                GameAllInfo.SelfRole.State = moveState;
                moveState.roleLogic = GameAllInfo.SelfRole;
            }

            //视为AnyState处理

            if (Input.GetKeyDown(KeyCode.W))
            {
            }
            else if (Input.GetKey(KeyCode.S))
            {

            }
            else if (Input.GetKey(KeyCode.A))
            {

            }
            else if (Input.GetKey(KeyCode.D))
            {

            }
        }
    }
}
