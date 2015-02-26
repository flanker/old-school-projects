namespace MySolution.Module
{
    partial class TaskActionsController
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
            this.SetTaskAction = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // SetTaskAction
            // 
            this.SetTaskAction.Caption = "Set Task";
            this.SetTaskAction.Category = "RecordEdit";
            this.SetTaskAction.ConfirmationMessage = null;
            this.SetTaskAction.Id = "SetTaskAction";
            this.SetTaskAction.ImageName = null;
            this.SetTaskAction.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.SetTaskAction.Shortcut = null;
            this.SetTaskAction.Tag = null;
            this.SetTaskAction.TargetObjectsCriteria = null;
            this.SetTaskAction.TargetViewId = null;
            this.SetTaskAction.ToolTip = null;
            this.SetTaskAction.TypeOfView = null;
            this.SetTaskAction.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.SetTaskAction_Execute);
            // 
            // TaskActionsController
            // 
            this.Activated += new System.EventHandler(this.TaskActionsController_Activated);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction SetTaskAction;
    }
}
