namespace kaogu_0730.Module
{
    partial class RemainMarkChangeController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ShowRemainChangeAction = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // ShowRemainChangeAction
            // 
            this.ShowRemainChangeAction.AcceptButtonCaption = null;
            this.ShowRemainChangeAction.CancelButtonCaption = null;
            this.ShowRemainChangeAction.Caption = "由遗物标签生成更改记录";
            this.ShowRemainChangeAction.Category = "RecordEdit";
            this.ShowRemainChangeAction.ConfirmationMessage = null;
            this.ShowRemainChangeAction.Id = "ShowRemainChangeAction";
            this.ShowRemainChangeAction.ImageName = null;
            this.ShowRemainChangeAction.Shortcut = null;
            this.ShowRemainChangeAction.Tag = null;
            this.ShowRemainChangeAction.TargetObjectsCriteria = null;
            this.ShowRemainChangeAction.TargetViewId = null;
            this.ShowRemainChangeAction.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.ShowRemainChangeAction.ToolTip = null;
            this.ShowRemainChangeAction.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.ShowRemainChangeAction.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.ShowRemainChangeAction_CustomizePopupWindowParams);
            // 
            // RemainMarkChangeController
            // 
            this.Activated += new System.EventHandler(this.RemainMarkChangeController_Activated);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction ShowRemainChangeAction;

    }
}
