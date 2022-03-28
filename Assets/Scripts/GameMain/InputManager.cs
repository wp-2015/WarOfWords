using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WP;

public class InputManager : Singleton_CSharp<InputManager>
{
    public static KeyCode CheckMoveKey()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return KeyCode.W;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            return KeyCode.S;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            return KeyCode.A;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            return KeyCode.D;
        }
        return KeyCode.None;
    }

    public static KeyCode CheckSkillKey()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            return KeyCode.J;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            return KeyCode.S;
        }
        return KeyCode.None;
    }

    public void Update()
    {
        var roleLogic = GameAllInfo.SelfRole;
        var roleState = roleLogic.State.EntityState;
        if (InputManager.CheckSkillKey() != KeyCode.None)
        {

        }
        else if (InputManager.CheckMoveKey() != KeyCode.None)
        {
            if (roleState == EntityState.MoveUpdateInput)
            {
                var msui = roleLogic.State as MoveStateUpdateInput;
                msui.InputKeyCode = InputManager.CheckMoveKey();
            }
            else
            {
                var idle = ObjectPool<MoveStateUpdateInput>.Instance.Get();
                idle.roleLogic = roleLogic;
                idle.InputKeyCode = InputManager.CheckMoveKey();
                roleLogic.State = idle;
            }
        }
        else if(roleState != EntityState.RoleIdle)
        {
            var idle = ObjectPool<RoleIdleState>.Instance.Get();
            idle.roleLogic = roleLogic;
            roleLogic.State = idle;
        }
    }
}
