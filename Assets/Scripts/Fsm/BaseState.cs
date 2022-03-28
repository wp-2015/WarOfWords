using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP
{
    public class BaseState : PoolObj
    {
        public EntityState EntityState;
        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Leave() { }
        public virtual void FixedUpdate() { }
    }
}
