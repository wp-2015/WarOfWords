using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public class TimeHandleManager : Singleton_CSharp<TimeHandleManager>
    {
        private struct TimeWheelItem
        {
            public ulong id;
            public long milliSecond;
            public Action cb;
        }
        private Dictionary<ulong, TimeWheelItem> dicTimeWheel = new Dictionary<ulong, TimeWheelItem>();
        private ulong lIndex = 0;
        public ulong AddHandleMillisecond(int ms, Action cb)
        {
            var endMillisencond = ms + GameUtils.GetNowMilliseconds();
            dicTimeWheel.Add(lIndex, new TimeWheelItem(){id = lIndex, cb = cb, milliSecond = endMillisencond});
            return lIndex++;
        }

        public void RemoveHandle(ulong id)
        {
            if (dicTimeWheel.ContainsKey(id))
                dicTimeWheel.Remove(id);
        }

        //TODO:这里为了防止作弊，需要获取的是服务器现在的时间
        
        public void Update()
        {
            var nowMillisecond = GameUtils.GetNowMilliseconds();
            foreach (var dicItem in dicTimeWheel)
            {
                var item = dicItem.Value;
                if (item.milliSecond <= nowMillisecond)
                {
                    item.cb?.Invoke();
                    lToRemoveDic.Add(dicItem.Key);
                }
            }

            if (lToRemoveDic.Count > 0)
            {
                foreach (var id in lToRemoveDic)
                {
                    dicTimeWheel.Remove(id);
                }
                lToRemoveDic.Clear();
            }
        }

        private List<ulong> lToRemoveDic = new List<ulong>();
    }
}