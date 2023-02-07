using System;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public static class UIFromName
    {
        public const string MenuForm = "MenuForm";
        public const string SelectForm = "SelectForm";
        public const string LoadGameForm = "LoadGame";
        public const string MainForm = "MainForm";
        public const string DiscipleForm = "DiscipleForm";
        public const string PrepareForm = "PrepareForm";
        public const string BattleForm = "BattleForm";
        public const string ActionForm = "ActionForm";
        public const string ReleaseSkillForm = "ReleaseSkillForm";
        
        public const string CommonTips = "CommonTips";
        public const string BattleUnitInfo = "BattleUnitInfo";
        public const string BattleStateEffect = "BattleStateEffect";
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