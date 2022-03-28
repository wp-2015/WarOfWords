using System.Collections.Generic;
using UnityEngine;

namespace WP
{
    public class EntityManager : UnitySingleton<EntityManager>
    {
        public RoleLogic SelfRole;
        private long iEntityIndex = 0;
        private Dictionary<string, List<Entity>> dicAllEntity = new Dictionary<string, List<Entity>>();

        public T MakeEntity<T>() where T : Entity, new()
        {
            var entity = ObjectPool<T>.Instance.Get();
            entity.Init(iEntityIndex++);

            var entityTypeName = typeof(T).Name;
            if (!dicAllEntity.TryGetValue(entityTypeName, out List<Entity> res))
            {
                res = new List<Entity>();
                dicAllEntity.Add(entityTypeName, res);
            }
            res.Add(entity);

            return entity;
        }

        public void Release<T>(T entity) where T : Entity, new()
        {
            var entityTypeName = typeof(T).Name;
            if (!dicAllEntity.TryGetValue(entityTypeName, out List<Entity> res))
            {
                Debug.LogError(string.Format("没有找到{0}类型的管理数组, 无法回收", entityTypeName));
            }
            res.Remove(entity);
            ObjectPool<T>.Instance.Release(entity);
        }

        public void ShowAllEntity()
        {
            foreach(var lEntity in dicAllEntity)
            {
                Debug.Log("Type: " + lEntity.Key);
                foreach(var entity in lEntity.Value)
                {
                    Debug.Log("id: " + entity.id);
                }
            }
        }
    }
}
