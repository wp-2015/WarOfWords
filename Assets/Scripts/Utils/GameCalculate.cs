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
            else if (key == KeyCode.D)
            {
                roleLogic.pos = new Vector3(pos.x + speed, pos.y);
            }
            GameUtils.ShowLog(string.Format("动了，他动了，{1}要到到<{0}>去了", roleLogic.pos, roleLogic.id));
        }
    }
}
