using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : UnitySingleton<InputManager>
{
    public static KeyCode CheckMoveKey()
    {
        if (Input.GetKeyDown(KeyCode.W))
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
}
