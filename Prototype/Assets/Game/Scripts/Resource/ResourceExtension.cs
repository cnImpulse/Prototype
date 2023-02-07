using System;
using GameFramework.Resource;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public static class ResourceExtension
    {
        public static void LoadAsset(this ResourceComponent resourceComponent, string assetName, LoadAssetSuccessCallback onLoadSuccess)
        {
            if (GameEntry.Resource.HasAsset(assetName) == HasAssetResult.NotExist)
            {
                Log.Error("��Դ�����ڣ�");
                return;
            }

            resourceComponent.LoadAsset(assetName, new LoadAssetCallbacks(onLoadSuccess));
        }

        public static void LoadAsset(this ResourceComponent resourceComponent, string assetName, Type type, LoadAssetSuccessCallback onLoadSuccess)
        {
            if (GameEntry.Resource.HasAsset(assetName) == HasAssetResult.NotExist)
            {
                Log.Error("��Դ�����ڣ�");
                return;
            }

            resourceComponent.LoadAsset(assetName, type, new LoadAssetCallbacks(onLoadSuccess));
        }
    }
}