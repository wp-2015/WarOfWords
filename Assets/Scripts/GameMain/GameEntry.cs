using UnityEngine;
using Utils;
using WP.OtherConfig;

namespace WP
{
    public class GameEntry : UnitySingleton<GameEntry>
    {
        public void Init()
        {
            GameConfigs.Init();
        }
    }
}