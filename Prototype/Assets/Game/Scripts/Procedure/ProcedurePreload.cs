using FairyGUI;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ProtoType
{
    public class ProcedurePreload : ProcedureBase
    {
        private const string DefaultFont = "mplus_hzk_12";
        private const string UIPackageOath = "Assets/Game/Res/Fgui/CommonUI";

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            Log.Info("预加载开始。");
            Preload();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (GameEntry.Cfg.EndLoad)
            {
                Log.Info("预加载结束。");
                ChangeState<ProcedureMain>(procedureOwner);
            }
        }

        private void Preload()
        {
            GameEntry.Cfg.LoadTables();

            UIConfig.defaultFont = DefaultFont;
            UIPackage.AddPackage(UIPackageOath);
            FGUI.CommonUI.CommonUIBinder.BindAll();
        }
    }
}
