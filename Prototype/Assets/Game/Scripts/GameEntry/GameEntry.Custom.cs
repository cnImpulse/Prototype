using UnityEngine;
using GFGameEntry = UnityGameFramework.Runtime.GameEntry;

namespace ProtoType
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        /// <summary>
        /// 配置表组件
        /// </summary>
        public static CfgComponent Cfg
        {
            get;
            private set;
        }

        private static void InitCustomComponents()
        {
            Cfg = UnityGameFramework.Runtime.GameEntry.GetComponent<CfgComponent>();
        }
    }
}
