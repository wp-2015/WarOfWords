using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WP
{
    public class GameCalculate
    {
        public static void MoveCalculate(RoleLogic roleLogic, KeyCode key, float speed)
        {
            var pos = roleLogic.pos;
            if(key == KeyCode.W)
            {
                roleLogic.pos = new Vector3(pos.x, pos.y + speed);
            }
            else if(key == KeyCode.S)
            {
                roleLogic.pos = new Vector3(pos.x, pos.y - speed);
            }
            else if (key == KeyCode.A)
            {
                roleLogic.pos = new Vector3(pos.x - speed, pos.y);
            }
            else if (key == KeyCode.S)
            {
                roleLogic.pos = new Vector3(pos.x + speed, pos.y);
            }
        }
    }
}
