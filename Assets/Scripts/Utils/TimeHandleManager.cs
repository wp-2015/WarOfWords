using System;
using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public interface ITimeHandleUpdate
    {
        void Update();
    }
    public class TimeHandleManager : Singleton_CSharp<TimeHandleManager>
    {
        private class TimeWheelItem
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
            dicToAdd.Add(lIndex, new TimeWheelItem(){id = lIndex, cb = cb, milliSecond = endMillisencond});
            return lIndex++;
        }

        public void RemoveHandle(ulong id)
        {
            lToRemoveDic.Add(id);
        }

        private Dictionary<ulong, ITimeHandleUpdate> dicUpdateItem = new Dictionary<ulong, ITimeHandleUpdate>();
        public ulong AddUpdateHandle(ITimeHandleUpdate updateHandle)
        {
            dicUpdateItem.Add(lIndex, updateHandle);
            return lIndex++;
        }

        public void RemoveUpdateHandle(ulong id)
        {
            lTimeUpdateRemove.Add(id);
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
            if (dicToAdd.Count > 0)
            {
                foreach (var dicToAddItem in dicToAdd)
                {
                    dicTimeWheel.Add(dicToAddItem.Key, dicToAddItem.Value);
                }
                dicToAdd.Clear();
            }
            if (lToRemoveDic.Count > 0)
            {
                foreach (var id in lToRemoveDic)
                {
                    dicTimeWheel.Remove(id);
                }
                lToRemoveDic.Clear();
            }

            foreach (var dicItem in dicUpdateItem)
            {
                var item = dicItem.Value;
                item?.Update();
            }

            if (lTimeUpdateRemove.Count > 0)
            {
                foreach (var id in lTimeUpdateRemove)
                {
                    dicUpdateItem.Remove(id);
                }
                lTimeUpdateRemove.Clear();
            }
        }

        private List<ulong> lToRemoveDic = new List<ulong>();
        private Dictionary<ulong, TimeWheelItem> dicToAdd = new Dictionary<ulong, TimeWheelItem>();
        
        private List<ulong> lTimeUpdateRemove = new List<ulong>();
    }
}