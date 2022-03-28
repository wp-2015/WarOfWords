using System;
using UnityEngine;
using Utils;
using WP.OtherConfig;

namespace WP
{
    public class GameEntry : Singleton_CSharp<GameEntry>
    {
        public void Init()
        {
            GameConfigs.Init();
        }

        public void Update()
        {
            EntityManager.Instance.Update();
        }
    }
}