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
            return KeyCode.K;
        }
        return KeyCode.None;
    }

    public void Update()
    {
        var roleLogic = GameAllInfo.SelfRole;
        var roleState = roleLogic.State.EntityState;
        //技能响应级最高
        if (InputManager.CheckSkillKey() != KeyCode.None && ((RoleState)roleLogic.State).canSkill)
        {
            var idle = ObjectPool<SkillState>.Instance.Get();
            idle.roleLogic = roleLogic;
            idle.SkillID = 0;
            roleLogic.State = idle;
        }
        //如果输入的是移动
        else if (InputManager.CheckMoveKey() != KeyCode.None && ((RoleState)roleLogic.State).canMove)
        {
            //如果当前已经是移动状态
            if (roleState == EntityState.MoveUpdateInput)
            {
                var msui = roleLogic.State as MoveStateUpdateInput;
                msui.InputKeyCode = InputManager.CheckMoveKey();
            }
            //如果现在不是移动状态，要进入移动状态
            else
            {
                var idle = ObjectPool<MoveStateUpdateInput>.Instance.Get();
                idle.roleLogic = roleLogic;
                idle.InputKeyCode = InputManager.CheckMoveKey();
                roleLogic.State = idle;
            }
        }
        //什么输入也没有，当前还是不是待机Idle状态，则进入Idle状态
        else if(roleState != EntityState.RoleIdle && ((RoleState)roleLogic.State).isOver)
        {
            var idle = ObjectPool<RoleIdleState>.Instance.Get();
            idle.roleLogic = roleLogic;
            roleLogic.State = idle;
        }
    }
}
