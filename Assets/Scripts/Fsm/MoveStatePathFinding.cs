using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WP
{
    public class MoveStatePathFinding : BaseState
    {
        public Vector3 v3Destination;

        public override void Enter()
        {
            base.Enter();
            EntityState = EntityState.MovePathFinding;
        }
    }
}
