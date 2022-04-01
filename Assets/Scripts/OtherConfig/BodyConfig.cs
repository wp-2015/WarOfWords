using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    [CreateAssetMenu(fileName = "CustomScriptableObject", menuName = "CustomConfig/BodyConfig")]
    public class BodyConfig : ScriptableObject
    {
        public List<BodyInfo> lc = new List<BodyInfo>();
    }
    
    [Serializable]
    public class BodyInfo
    {
        public int Strength;
        public string[] Des;
        public string[] Tag;
    }
}