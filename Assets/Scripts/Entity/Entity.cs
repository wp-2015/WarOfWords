using UnityEngine;

namespace WP
{
    public class Entity : PoolObj
    {
        public long id;
        public Vector3 pos;

        private BaseState baseState;
        public BaseState State 
        {
            get{return baseState;}
            set
            {
                baseState?.Leave();
                baseState = value;
                baseState.Enter();
            }
        }

        public virtual void Init(long id)
        {
            this.id = id;
        }

        public virtual void Update()
        {
            State?.Update();
        }

        public virtual void FixedUpdate()
        {
            State?.FixedUpdate();
        }
    }
}
