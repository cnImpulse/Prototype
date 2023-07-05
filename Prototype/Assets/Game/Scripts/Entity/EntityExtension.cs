using System;
using UnityEngine;
using GameFramework;
using GameFramework.Resource;
using UnityGameFramework.Runtime;

namespace ProtoType
{
    public static class EntityExtension
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        private static int s_SerialId = 0;

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return ++s_SerialId;
        }

        public static void HideEntity(this EntityComponent entityComponent, Entity entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }

        public static T GetEntityData<T>(this EntityComponent entityComponent, int entityId)
            where T : EntityData
        {
            return (entityComponent.GetEntity(entityId)?.Logic as Entity)?.Data as T;
        }

        public static T GetEntityLogic<T>(this EntityComponent entityComponent, int entityId)
            where T : EntityLogic
        {
            return entityComponent.GetEntity(entityId)?.Logic as T;
        }
    }
}
