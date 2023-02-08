﻿using FairyGUI;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace HEDAO
{
    public class ProcedurePreload : ProcedureBase
    {
        private bool m_PreloadEnd = false;
        private const string DefaultFont = "mplus_hzk_12";
        private const string UIPackageOath = "Assets/Game/Res/Fgui/CommonUI";

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_PreloadEnd = false;

            Log.Info("预加载开始。");
            Preload();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_PreloadEnd)
            {
                return;
            }

            ChangeState<ProcedureMain>(procedureOwner);
        }

        private void Preload()
        {
            //GameEntry.Cfg.InitTables();

            UIConfig.defaultFont = DefaultFont;
            UIPackage.AddPackage(UIPackageOath);
            FGUI.CommonUI.CommonUIBinder.BindAll();

            m_PreloadEnd = true;
            Log.Info("预加载结束。");
        }
    }
}
