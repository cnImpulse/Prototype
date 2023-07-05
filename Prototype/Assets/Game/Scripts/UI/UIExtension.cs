using System;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

namespace ProtoType
{
    public static class UIFromName
    {

    }

    public static class UICfg
    {
        private static Dictionary<string, UICfgItem> cfg = new Dictionary<string, UICfgItem>()
        {

        };

        public static UICfgItem GetCfg(string name)
        {
            return cfg[name];
        }
    }

    public class UICfgItem
    {
        public Type FormType = default;
        public string FormURL = "";
        public string FormGroup = "Default";

        public UICfgItem(Type type, string url, string group = "Default")
        {
            FormType = type;
            FormURL = url;
            FormGroup = group;
        }
    }

    public static class UIExtension
    {
        public static int OpenUIForm(this UIComponent uiComponent, string name, object data = default)
        {
            return uiComponent.OpenUIForm(name, "Default", data);
        }

        public static void CloseUIForm(this UIComponent uiComponent, string name)
        {
            var uiForms = uiComponent.GetUIForms(name);
            foreach(var form in uiForms)
            {
                if (form.UIFormAssetName == name)
                {
                    uiComponent.CloseUIForm(form);
                }
            }
        }
    }
}