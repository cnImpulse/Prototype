using System;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Resource;
using UnityGameFramework.Runtime;
using Bright.Serialization;
using System.IO;
using Cfg;

namespace HEDAO
{
    public class CfgComponent : GameFrameworkComponent
    {

        public Tables Tables
        {
            get;
            private set;
        }

        public void InitTables()
        {
            Tables = new Tables(LoadByteBuf);
        }

        private static ByteBuf LoadByteBuf(string file)
        {
            return new ByteBuf(File.ReadAllBytes($"{Application.dataPath}/Game/Res/Cfg/Bytes/{file}.bytes"));
        }
    }
}
