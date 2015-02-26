namespace MySolution.Module
{
    partial class ClearFieldsController
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
            this.ClearFieldsAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // ClearFieldsAction
            // 
            this.ClearFieldsAction.Caption = "Clear Fields";
            this.ClearFieldsAction.Category = "RecordEdit";
            this.ClearFieldsAction.ConfirmationMessage = "Do you really need to clear all fields?";
            this.ClearFieldsAction.Id = "ClearFieldsAction";
            this.ClearFieldsAction.ImageName = null;
            this.ClearFieldsAction.Shortcut = null;
            this.ClearFieldsAction.Tag = null;
            this.ClearFieldsAction.TargetObjectsCriteria = null;
            this.ClearFieldsAction.TargetViewId = null;
            this.ClearFieldsAction.ToolTip = null;
            this.ClearFieldsAction.TypeOfView = null;
            this.ClearFieldsAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ClearFieldsAction_Execute);
            // 
            // ClearFieldsController
            // 
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.Activated += new System.EventHandler(this.ClearFieldsController_Activated);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction ClearFieldsAction;
    }
}
