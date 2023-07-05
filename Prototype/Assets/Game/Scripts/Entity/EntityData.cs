using System;
using UnityEngine;

namespace ProtoType
{
    public abstract class EntityData
    {
        private int m_Id = 0;

        private string m_Name = "Entity";

        /// <summary>
        /// 实体编号。
        /// </summary>
        public int Id => m_Id;

        /// <summary>
        /// 单位名称。
        /// </summary>
        public string Name
        {
            get => m_Name;
            set => m_Name = value;
        }

        public EntityData()
        {
            m_Id = GameEntry.Entity.GenerateSerialId();
        }
    }
}


