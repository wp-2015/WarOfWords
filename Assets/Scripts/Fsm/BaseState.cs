using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP
{
    public abstract class BaseState
    {
        public abstract void Enter();
        public abstract void Update();
        public abstract void Leave();
    }
}
