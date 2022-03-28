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
            InputManager.Instance.Update();
        }
    }
}
