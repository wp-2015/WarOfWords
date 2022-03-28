using UnityEngine;

namespace WP
{
    public class Entity : PoolObj
    {
        public long id;
        public Vector3 pos;
        public BaseState state;

        public virtual void Init(long id)
        {
            this.id = id;
        }

        public virtual void Update()
        {
            state?.Update();
        }
    }
}
