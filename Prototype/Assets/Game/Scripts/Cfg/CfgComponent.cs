using System;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Resource;
using UnityGameFramework.Runtime;
using Bright.Serialization;

namespace ProtoType
{
    public class CfgComponent : GameFrameworkComponent
    {
        public string Path = "Assets/Game/Res/Cfg/Bytes/";

        [NonSerialized]
        public bool EndLoad = false;

        private Dictionary<string, ByteBuf> ByteBufList = new Dictionary<string, ByteBuf>();

        public Cfg.Tables Tables
        {
            get;
            private set;
        }

        public void LoadTables()
        {
            if (Cfg.Tables.Assets.Length == 0)
            {
                EndLoad = true;
                return;
            }

            for (int i = 0; i < Cfg.Tables.Assets.Length; ++i)
            {
                GameEntry.Resource.LoadAsset($"{Path}{Cfg.Tables.Assets[i]}.bytes", OnAssetLoadScuess);
            }
        }

        private ByteBuf LoadByteBuf(string file)
        {
            return ByteBufList[file];
        }

        public void OnAssetLoadScuess(string assetName, object asset, float duration, object userData)
        {
            TextAsset textAsset = asset as TextAsset;
            ByteBufList.Add(textAsset.name, new ByteBuf(textAsset.bytes));

            if (!EndLoad && ByteBufList.Count == Cfg.Tables.Assets.Length)
            {
                Tables = new Cfg.Tables(LoadByteBuf);
                EndLoad = true;
            }
        }
    }
}
