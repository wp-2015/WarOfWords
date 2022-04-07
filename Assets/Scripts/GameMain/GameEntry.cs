using System;
using UnityEngine;

namespace WP
{
    public class GameEntry : Singleton_CSharp<GameEntry>
    {
        public void Init()
        {
            BodyConfigManager.Instance.Init();
            SkillEffectManager.Instance.LoadConfig();
        }

        public void Update()
        {
            EntityManager.Instance.Update();
        }
    }
}